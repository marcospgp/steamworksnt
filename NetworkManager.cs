using Steamworksnt.Internal;
using Steamworksnt.SteamworksApi;
using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// This component should be placed on a single object in the scene.
/// A recommended approach is to include it in an empty "NetworkManager" object.
/// </summary>
public class NetworkManager : MonoBehaviour
{
    // Singleton pattern.
    private static NetworkManager instance;

    [SerializeField]
    private GameObject playerPrefab;

    private IntPtr iSteamNetworkingUtils;

    private void Awake()
    {
        EnsureSingleton();
        Init();
        // _ = StartCoroutine(SendMessages());

        iSteamNetworkingUtils = Api.SteamAPI_SteamNetworkingUtils_SteamAPI_v004();

        Api.SteamAPI_ISteamNetworkingUtils_InitRelayNetworkAccess(iSteamNetworkingUtils);

        SteamRelayNetworkStatus_t details = default;

        UnityEngine.Debug.Log("Getting steam relay network availability...");

        ESteamNetworkingAvailability availability =
            Api.SteamAPI_ISteamNetworkingUtils_GetRelayNetworkStatus(
                iSteamNetworkingUtils,
                ref details
            );

        UnityEngine.Debug.Log("Got availability!");

        UnityEngine.Debug.Log($"Getting steam user stats...");

        var x = Api.SteamAPI_SteamUserStats_v012();
        var result = Api.SteamAPI_ISteamUserStats_RequestCurrentStats(x);

        UnityEngine.Debug.Log($"got results");
    }

    private void Update()
    {
        RunFrame();
    }

    private void EnsureSingleton()
    {
        if (NetworkManager.instance != null)
        {
            Destroy(this);
            throw new Exception(
                "More than one instance of NetworkManager detected. Destroying latest one..."
            );
        }

        instance = this;
    }

    private IEnumerator SendMessages()
    {
        // yield return new WaitForSecondsRealtime(5f);

        for (int i = 0; i < 100; i++)
        {
            Networking.SendMessage(i.ToString());
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    private void Init()
    {
        // Shut down Steam API when quitting.
        Application.quitting += () => ShutDown();

        if (Api.SteamAPI_RestartAppIfNecessary())
        {
            UnityEngine.Debug.Log(
                "\"SteamAPI_RestartAppIfNecessary\" returned true. Stopping process..."
            );
            Application.Quit();
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

        UnityEngine.Debug.Log("Steamworks SDK init successful.");
    }

    /// <summary>
    /// This should be called once each Update().
    /// </summary>
    private void RunFrame() => Callbacks.RunFrame();

    /// <summary>
    /// Call this during application shutdown. Steam doesn't say this is
    /// required, only to do so "if possible".
    /// </summary>
    private void ShutDown() => Api.SteamAPI_Shutdown();
}
