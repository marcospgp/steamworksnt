using System;
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

            CallbackMsg_t data = default;

            while (Api.SteamAPI_ManualDispatch_GetNextCallback(hSteamPipe, ref data))
            {
                try
                {
                    OnCallback(data);
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

        private static void OnCallback(CallbackMsg_t data)
        {
            UnityEngine.Debug.Log(
                $"got steam callback with type {data.iCallback}. See k_iCallback enum to decode."
            );
            // TODO: handle callbacks
        }
    }
}
