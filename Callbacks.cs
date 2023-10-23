using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Steamworksnt.SteamworksApi;

namespace Steamworksnt
{
    public static class Callbacks
    {
        private static readonly Int32 hSteamPipe = Api.SteamAPI_GetHSteamPipe();
        private static readonly HashSet<Int32> validCallbackIds = new HashSet<Int32>(
            (Int32[])Enum.GetValues(typeof(Callback))
        );

        /// <summary>
        /// Must be called once before anything else on this class.
        /// </summary>
        public static void Init()
        {
            // We use manual callbacks and do not call SteamAPI_RunCallbacks().
            Api.SteamAPI_ManualDispatch_Init();
        }

        /// <summary>
        /// This should be called once per frame (that is, in Update()), as it
        /// is similar to "SteamAPI_RunCallbacks()" about which the Steamworks
        /// SDK docs say "Most games call this once per render-frame".
        /// </summary>
        public static void RunFrame()
        {
            UnityEngine.Debug.Log($"hsteampipe: {hSteamPipe}");
            Api.SteamAPI_ManualDispatch_RunFrame(hSteamPipe);

            // Declared before while loop for efficiency, could be declared as
            // an "out" parameter below instead. This would make it easier to
            // catch potential SDK issues by noticing an uninitialized callback
            // struct.
            CallbackMsg_t callback = default;

            while (Api.SteamAPI_ManualDispatch_GetNextCallback(hSteamPipe, ref callback))
            {
                try
                {
                    OnCallback(callback);
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
                finally
                {
                    Api.SteamAPI_ManualDispatch_FreeLastCallback(hSteamPipe);
                }
            }
        }

        private static void OnCallback(CallbackMsg_t callback)
        {
            // Some callbacks are received with an unrecognized ID, which we ignore.
            // See more: https://github.com/Facepunch/Facepunch.Steamworks/issues/507#issuecomment-1771804971
            if (!validCallbackIds.Contains((Int32)callback.m_iCallback))
            {
                return;
            }

            UnityEngine.Debug.Log(
                "(Steamworks SDK callback)\n\n"
                    + $"{callback.m_iCallback}\n\n"
                    + $"m_hSteamUser: {callback.m_hSteamUser}\n"
                    + $"m_pubParam: {callback.m_pubParam}\n"
                    + $"m_cubParam: {callback.m_cubParam}\n"
            );

            // Special case - asynchronous Steamworks SDK API calls.
            if (callback.m_iCallback == Callback.SteamAPICallCompleted_t)
            {
                HandleApiCallCompleted(callback);
            }
        }

        private static void HandleApiCallCompleted(CallbackMsg_t callback)
        {
            SteamAPICallCompleted_t call = Marshal.PtrToStructure<SteamAPICallCompleted_t>(
                callback.m_pubParam
            );

            IntPtr resultPtr = Marshal.AllocHGlobal((int)callback.m_cubParam);

            try
            {
                bool failed = false;

                bool success = Api.SteamAPI_ManualDispatch_GetAPICallResult(
                    hSteamPipe,
                    call.m_hAsyncCall,
                    resultPtr,
                    // Not sure if these two parameters should be from "call" or
                    // "callback". Steamworks SDK code example seems to suggest
                    // it should be "callback", but that doesn't make much
                    // sense.
                    (int)call.m_cubParam,
                    (Callback)call.m_iCallback,
                    ref failed
                );

                if (!success)
                {
                    // Steamworks SDK code example in "steam_api.h" ignores this
                    // scenario.
                    // Initially we threw an error here, but that error was
                    // being thrown even when no API call result was expected
                    // (no async SDK method had been called).
                    // Maybe this is related to how we get unrecognized
                    // callbacks (with IDs that are not part of the callback
                    // IDs enum).
                    return;
                }

                if (failed)
                {
                    throw new Exception(
                        "Failure signaled by Steamworks SDK when attempting to "
                            + "fetch asynchronous API call result."
                    );
                }

                UnityEngine.Debug.Log(
                    $"Got Steamworks SDK API call completed callback:"
                        + $"call.m_hAsyncCall: {call.m_hAsyncCall}"
                        + $"call.m_iCallback: {call.m_iCallback}"
                        + $"call.m_cubParam: {call.m_cubParam}"
                );

                // TODO: When implementing an actual API call, set things up so
                // caller specifies type of struct they are expecting, then we
                // can create and populate it from "resultPtr".
            }
            finally
            {
                Marshal.FreeHGlobal(resultPtr);
            }
        }
    }
}
