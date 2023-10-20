using System;
using System.Collections;
using System.Text;
using Steamworksnt.SteamworksApi;
using UnityEngine;

namespace Steamworksnt
{
    public static class Networking
    {
        private static readonly IntPtr iSteamNetworkingMessages =
            Api.SteamAPI_SteamNetworkingMessages_SteamAPI_v002();
        private static readonly IntPtr iSteamNetworkingUtils =
            Api.SteamAPI_SteamNetworkingUtils_SteamAPI_v004();

        /// <summary>
        /// This should be called once before using this class.
        /// </summary>
        public static void Init()
        {
            // Let Steam know we intend to use their relay network (init early).
            Api.SteamAPI_ISteamNetworkingUtils_InitRelayNetworkAccess(iSteamNetworkingUtils);

            // _ = StartCoroutine(SendMessages());
        }

        public static void SendMessage(string message)
        {
            UnityEngine.Debug.Log($"Sending message {message}");

            byte[] bytes = Encoding.UTF8.GetBytes(message);

            EResult result = Api.SteamAPI_ISteamNetworkingMessages_SendMessageToUser(
                iSteamNetworkingMessages,
                new SteamNetworkingIdentity(),
                bytes,
                (uint)bytes.Length,
                0,
                0
            );

            UnityEngine.Debug.Log($"Got result: {result}");
        }

        private static IEnumerator SendMessages()
        {
            // yield return new WaitForSecondsRealtime(5f);

            for (int i = 0; i < 100; i++)
            {
                Networking.SendMessage(i.ToString());
                yield return new WaitForSecondsRealtime(1f);
            }
        }
    }
}
