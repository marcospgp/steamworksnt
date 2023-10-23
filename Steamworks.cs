using System;
using System.Runtime.InteropServices;
using Steamworksnt.SteamworksApi;
using UnityEngine;

namespace Steamworksnt
{
    public static class Steamworks
    {
        /// <summary>
        /// Init Steamworks SDK before any code has a chance to call it.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Init()
        {
            // Shut down Steamworks SDK when quitting.
            Application.quitting += () => Api.SteamAPI_Shutdown();

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

            // Hook warning & debug messages
            Api.SteamAPI_ISteamUtils_SetWarningMessageHook(
                Api.SteamAPI_SteamUtils_v010(),
                Steamworks.OnWarningMessage
            );

            Callbacks.Init();

            UnityEngine.Debug.Log("Steamworks SDK init successful.");
        }

        private static void OnWarningMessage(Int32 nSeverity, IntPtr pchDebugText)
        {
            UnityEngine.Debug.LogWarning($"Steamworks SDK warning (severity {nSeverity}):");
            UnityEngine.Debug.LogWarning(Marshal.PtrToStringUni(pchDebugText));
        }
    }
}
