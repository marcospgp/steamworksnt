using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Steamworksnt.SteamworksApi;
using UnityEngine;

namespace Steamworksnt
{
    public static class Steamworks
    {
        // /// <summary>
        // /// Init Steamworks SDK before any code has a chance to call it.
        // /// </summary>
        // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        // private static void Init()
        // {
        //     // Shut down Steamworks SDK when quitting.
        //     Application.quitting += () => Api.SteamAPI_Shutdown();

        //     if (Api.SteamAPI_RestartAppIfNecessary())
        //     {
        //         UnityEngine.Debug.Log(
        //             "\"SteamAPI_RestartAppIfNecessary()\" returned true. Steam should "
        //                 + "now be starting a new process, so terminating this one..."
        //         );
        //         Application.Quit();
        //         return;
        //     }

        //     if (!Api.SteamAPI_IsSteamRunning())
        //     {
        //         Fail("Unable to init Steam SDK because the Steam client is not running.");
        //     }

        //     if (!Api.SteamAPI_Init())
        //     {
        //         Fail("Unable to init Steam SDK. See logs for more details.");
        //     }

        //     // Hook warning & debug messages
        //     Api.SteamAPI_ISteamUtils_SetWarningMessageHook(
        //         Api.SteamAPI_SteamUtils_v010(),
        //         Steamworks.OnWarningMessage
        //     );

        //     Callbacks.Init();

        //     UnityEngine.Debug.Log("Steamworks SDK init successful.");
        // }

        private static void OnWarningMessage(int nSeverity, IntPtr pchDebugText)
        {
            UnityEngine.Debug.LogWarning(
                $"Steamworks SDK warning (severity {nSeverity.ToString(CultureInfo.InvariantCulture)}):"
            );
            UnityEngine.Debug.LogWarning(Marshal.PtrToStringUni(pchDebugText));
        }

        private static void Fail(string message)
        {
#if UNITY_EDITOR
            UnityEditor.EditorUtility.DisplayDialog(
                "Steamworks SDK failure",
                $"{message}\nFurther calls to the Steamworks SDK may cause Unity to crash.",
                "Ok"
            );
#endif
            throw new Exception(message);
        }
    }
}
