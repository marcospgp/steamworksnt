using System;
using System.Runtime.InteropServices;
using Steamworksnt.SteamworksApi;

namespace Steamworksnt
{
    public static class Callbacks
    {
        private static Int32 hSteamPipe;

        /// <summary>
        /// Must be called once before anything else on this class.
        /// </summary>
        public static void Init()
        {
            // We use manual callbacks and do not call SteamAPI_RunCallbacks().
            Api.SteamAPI_ManualDispatch_Init();

            hSteamPipe = Api.SteamAPI_GetHSteamPipe();
        }

        /// <summary>
        /// This should be called once per frame (that is, in Update()), as it
        /// is similar to SteamAPI_RunCallbacks() about which the Steamworks SDK
        /// docs say "Most games call this once per render-frame".
        /// TODO: Consider making this async.
        /// </summary>
        public static void RunFrame()
        {
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

            UnityEngine.Debug.Log($"Got Steamworks SDK callback \"{callback.m_iCallback}\".");
            UnityEngine.Debug.Log($"callback.m_hSteamUser: {callback.m_hSteamUser}");
            UnityEngine.Debug.Log($"callback.m_pubParam: {callback.m_pubParam}");
            UnityEngine.Debug.Log($"callback.m_cubParam: {callback.m_cubParam}");

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
                    callback.m_cubParam,
                    callback.m_iCallback,
                    ref failed
                );

                if (!success)
                {
                    throw new Exception(
                        "Failed to get Steamworks SDK asynchronous API call result."
                    );
                }

                if (failed)
                {
                    throw new Exception(
                        "Failure signaled by Steamworks SDK when attempting to fetch asynchronous API call result."
                    );
                }

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
