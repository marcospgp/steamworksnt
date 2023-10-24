using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Steamworksnt.SteamworksApi;

namespace Steamworksnt
{
    public static class Friends
    {
        private static readonly IntPtr iSteamFriends = Api.SteamAPI_SteamFriends_v017();

        public static List<SteamUser> GetFriends()
        {
            var friends = new List<SteamUser>();

            int friendCount = Api.SteamAPI_ISteamFriends_GetFriendCount(
                iSteamFriends,
                EFriendFlags.k_EFriendFlagImmediate
            );

            for (int i = 0; i < friendCount; i++)
            {
                friends.Add(GetSteamUserByIndex(i));
            }

            return friends;
        }

        private static SteamUser GetSteamUserByIndex(int i)
        {
            ulong friendSteamId = Api.SteamAPI_ISteamFriends_GetFriendByIndex(
                iSteamFriends,
                i,
                EFriendFlags.k_EFriendFlagImmediate
            );

            IntPtr displayNamePtr = Api.SteamAPI_ISteamFriends_GetFriendPersonaName(
                iSteamFriends,
                friendSteamId
            );

            string displayName = Marshal.PtrToStringUTF8(displayNamePtr);

            return new SteamUser(friendSteamId, displayName);
        }
    }
}
