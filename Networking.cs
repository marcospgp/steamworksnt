using System;
using System.Text;
using Steamworksnt.SteamworksApi;

namespace Steamworksnt
{
    public static class Networking
    {
        /// <summary>
        /// This should be called once before using this class.
        /// </summary>
        public static void Init()
        {
            // Let Steam know we intend to use their relay network (init early).
            // Api.SteamAPI_ISteamNetworkingUtils_InitRelayNetworkAccess(iSteamNetworkingUtils);
        }

        public static void SendMessage(string message)
        {
            UnityEngine.Debug.Log($"Sending message \"{message}\"");

            byte[] bytes = Encoding.UTF8.GetBytes(message);

            EResult result = Api.SteamAPI_ISteamNetworkingMessages_SendMessageToUser(
                Steamworks.iSteamNetworkingMessages,
                new SteamNetworkingIdentity(),
                bytes,
                (uint)bytes.Length,
                0,
                0
            );

            UnityEngine.Debug.Log($"Got result: {result}");
        }
    }
}
