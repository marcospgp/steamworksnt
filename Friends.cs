using System;
using System.Collections.Generic;
using Steamworksnt.SteamworksApi;

namespace Steamworksnt
{
    public static class Friends
    {
        private static IntPtr iSteamFriends = Api.SteamAPI_SteamFriends_v017();

        public static List<(UInt64 steamId, string displayName)> GetFriends()
        {
            return new List<(ulong steamId, string displayName)>();
        }
    }
}
