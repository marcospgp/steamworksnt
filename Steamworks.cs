using System;
using System.Runtime.InteropServices;
using Steamworksnt.SteamworksApi;
using UnityEngine;

namespace Steamworksnt
{
    public static class Steamworks
    {
        public static IntPtr iSteamUtils;
        public static IntPtr iSteamNetworkingMessages;
        public static IntPtr iSteamNetworkingUtils;

        /// <summary>
        /// Init Steamworks SDK before any code has a chance to call it.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Init()
        {
            // Shut down Steamworks SDK when quitting.
            Application.quitting += () => Steamworks.Shutdown();

            if (Api.SteamAPI_RestartAppIfNecessary())
            {
                UnityEngine.Debug.Log(
                    "\"SteamAPI_RestartAppIfNecessary\" returned true. Steam should "
                        + "now be starting a new process, so terminating this one..."
                );
                Application.Quit();
                return;
            }

            if (!Api.SteamAPI_IsSteamRunning())
            {
                throw new Exception("Steam client is not running - unable to init Steam SDK.");
            }

            if (!Api.SteamAPI_Init())
            {
                throw new Exception("Unable to init Steam SDK. See logs for more details.");
            }

            Callbacks.Init();

            // Obtain interface pointers.
            iSteamUtils = Api.SteamAPI_SteamUtils_v010();
            iSteamNetworkingMessages = Api.SteamAPI_SteamNetworkingMessages_SteamAPI_v002();
            iSteamNetworkingUtils = Api.SteamAPI_SteamNetworkingUtils_SteamAPI_v004();

            // Hook warning & debug messages
            Api.SteamAPI_ISteamUtils_SetWarningMessageHook(
                iSteamUtils,
                Steamworks.OnWarningMessage
            );

            UnityEngine.Debug.Log("Steamworks SDK init successful.");
        }

        /// <summary>
        /// Call this during application shutdown. Steam doesn't say this is
        /// required, only to do so "if possible".
        /// </summary>
        public static void Shutdown()
        {
            Api.SteamAPI_Shutdown();
        }

        private static void OnWarningMessage(Int32 nSeverity, IntPtr pchDebugText)
        {
            UnityEngine.Debug.Log($"Steamworks SDK warning (severity {nSeverity})");

            UnityEngine.Debug.Log(Marshal.PtrToStringUni(pchDebugText));
        }
    }
}
