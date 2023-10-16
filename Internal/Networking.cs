using System;
using System.Text;
using Steamworksnt.SteamworksApi;

namespace Steamworksnt.Internal
{
    public static class Networking
    {
        /// <summary>
        /// Do not use this field directly.
        /// </summary>
        private static IntPtr? _iSteamNetworkingMessages = null;

        public static void SendMessage(string message)
        {
            UnityEngine.Debug.Log($"Sending message {message}");

            byte[] bytes = Encoding.UTF8.GetBytes(message);

            EResult result = Api.SteamAPI_ISteamNetworkingMessages_SendMessageToUser(
                GetInterface(),
                new SteamNetworkingIdentity(),
                bytes,
                (uint)bytes.Length,
                0,
                0
            );

            UnityEngine.Debug.Log($"Got result: {result}");
        }

        private static IntPtr GetInterface()
        {
            if (!_iSteamNetworkingMessages.HasValue)
            {
                _iSteamNetworkingMessages = Api.SteamAPI_SteamNetworkingMessages_SteamAPI_v002();
            }

            return _iSteamNetworkingMessages.Value;
        }
    }
}
