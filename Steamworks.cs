using System;
using Steamworksnt.SteamworksApi;

namespace Steamworksnt
{
    public enum InitResult
    {
        OK,
        AppRestartNecessary
    }

    public static class Steamworks
    {
        public static InitResult Init()
        {
            if (Api.SteamAPI_RestartAppIfNecessary())
            {
                return InitResult.AppRestartNecessary;
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

            return InitResult.OK;
        }

        /// <summary>
        /// Call this during application shutdown. Steam doesn't say this is
        /// required, only to do so "if possible".
        /// </summary>
        public static void Shutdown()
        {
            Api.SteamAPI_Shutdown();
        }
    }
}
