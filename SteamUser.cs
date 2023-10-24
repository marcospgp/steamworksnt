namespace Steamworksnt
{
    public readonly struct SteamUser
    {
        public readonly ulong steamId;
        public readonly string displayName;

        public SteamUser(ulong steamId, string displayName)
        {
            this.steamId = steamId;
            this.displayName = displayName;
        }
    }
}
