using System;
using System.Text;
using System.Threading.Tasks;
using Steamworksnt.SteamworksApi;

namespace Steamworksnt
{
    public static class Networking
    {
        private static readonly IntPtr iSteamNetworkingMessages =
            Api.SteamAPI_SteamNetworkingMessages_SteamAPI_v002();

        private static readonly IntPtr iSteamMatchmaking = Api.SteamAPI_SteamMatchmaking_v009();

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
                iSteamNetworkingMessages,
                new SteamNetworkingIdentity(),
                bytes,
                (uint)bytes.Length,
                0,
                0
            );

            UnityEngine.Debug.Log($"Got result: {result}");
        }

        public static async Task CreateLobby()
        {
            var call = Api.SteamAPI_ISteamMatchmaking_CreateLobby(
                iSteamMatchmaking,
                ELobbyType.k_ELobbyTypeFriendsOnly,
                250
            );

            LobbyCreated_t result = await call.GetResult();

            UnityEngine.Debug.Log($"Got lobby creation result!");
        }
    }
}
