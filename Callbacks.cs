using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Steamworksnt.SteamworksApi;

namespace Steamworksnt
{
    public static class Callbacks
    {
        private static readonly HashSet<Int32> validCallbackIds = new HashSet<Int32>(
            (Int32[])Enum.GetValues(typeof(Callback))
        );

        private static readonly Dictionary<ulong, (Action<object>, Type)> pendingApiCalls = new();

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
            Int32 hSteamPipe = Api.SteamAPI_GetHSteamPipe();

            if (hSteamPipe == 0)
            {
                return;
            }

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

        /// <summary>
        /// Should only be used by the "SteamAPICall_t" struct.
        /// </summary>
        public static Task<T> _GetApiCallResponse<T>(ulong apiCallId)
        {
            var tcs = new TaskCompletionSource<T>();

            pendingApiCalls.Add(
                apiCallId,
                ((object result) => tcs.SetResult((T)result), typeof(T))
            );

            return tcs.Task;
        }

        private static void OnCallback(CallbackMsg_t msg)
        {
            // Some callbacks are received with an unrecognized ID, which we ignore.
            // See more: https://github.com/Facepunch/Facepunch.Steamworks/issues/507#issuecomment-1771804971
            if (!validCallbackIds.Contains((Int32)msg.m_iCallback))
            {
                return;
            }

            // UnityEngine.Debug.Log(
            //     "(Steamworks SDK callback)\n\n"
            //         + $"{msg.m_iCallback}\n\n"
            //         + $"m_hSteamUser: {msg.m_hSteamUser}\n"
            //         + $"m_pubParam: {msg.m_pubParam}\n"
            //         + $"m_cubParam: {msg.m_cubParam}\n"
            // );

            // Special case - asynchronous Steamworks SDK API calls.
            if (msg.m_iCallback == Callback.SteamAPICallCompleted_t)
            {
                HandleApiCallCompleted(msg);
            }
        }

        private static void HandleApiCallCompleted(CallbackMsg_t msg)
        {
            Int32 hSteamPipe = Api.SteamAPI_GetHSteamPipe();

            SteamAPICallCompleted_t apiCall = Marshal.PtrToStructure<SteamAPICallCompleted_t>(
                msg.m_pubParam
            );

            // /!\ Important: not ignoring API call results with invalid IDs
            // was causing crashes with seemingly random stack traces on the
            // Unity editor log.
            // Note we also receive callbacks with invalid IDs, not just API
            // call results (and even when no SDK method that should trigger one
            // had been called).
            if (!validCallbackIds.Contains((Int32)apiCall.m_iCallback))
            {
                return;
            }

            if (!pendingApiCalls.ContainsKey(apiCall.m_hAsyncCall))
            {
                return;
            }

            var (callback, type) = pendingApiCalls[apiCall.m_hAsyncCall];

            _ = pendingApiCalls.Remove(apiCall.m_hAsyncCall);

            IntPtr resultPtr = Marshal.AllocHGlobal(msg.m_cubParam);

            try
            {
                bool failed = false;

                bool success = Api.SteamAPI_ManualDispatch_GetAPICallResult(
                    hSteamPipe,
                    apiCall.m_hAsyncCall,
                    resultPtr,
                    (int)apiCall.m_cubParam,
                    (Callback)apiCall.m_iCallback,
                    ref failed
                );

                if (!success)
                {
                    // Steamworks SDK code example in "steam_api.h" ignores a
                    // return value of "false".
                    throw new Exception("GetAPICallResult() returned false.");
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
                        + $"m_hAsyncCall: {apiCall.m_hAsyncCall}"
                        + $"m_iCallback: {apiCall.m_iCallback}"
                        + $"m_cubParam: {apiCall.m_cubParam}"
                );

                object result = Marshal.PtrToStructure(resultPtr, type);

                callback(result);
            }
            finally
            {
                Marshal.FreeHGlobal(resultPtr);
            }
        }
    }
}
