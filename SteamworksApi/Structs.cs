#pragma warning disable IDE1006 // Naming rule violations

using System;
using System.Runtime.InteropServices;

namespace Steamworksnt.SteamworksApi
{
    #region Callback structs

    // General callback message struct.
    // Comments included are from Steamworks SDK.
    [StructLayout(LayoutKind.Sequential, Pack = Api.PLATFORM_STRUCT_PACK_SIZE)]
    public struct CallbackMsg_t
    {
        public Int32 hSteamUser; // Specific user to whom this callback applies.
        public Int32 iCallback; // Callback identifier.  (Corresponds to the k_iCallback enum in the callback structure.)

        // uint8 *m_pubParam
        public IntPtr pubParam; // Points to the callback structure
        public Int32 cubParam; // Size of the data pointed to by m_pubParam
    };

    /// <summary>
    /// callback_id: 1281
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = Api.PLATFORM_STRUCT_PACK_SIZE)]
    public struct SteamRelayNetworkStatus_t
    {
        public ESteamNetworkingAvailability m_eAvail;
        public Int32 m_bPingMeasurementInProgress;
        public ESteamNetworkingAvailability m_eAvailNetworkConfig;
        public ESteamNetworkingAvailability m_eAvailAnyRelay;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string m_debugMsg;
    }

    #endregion

    #region Non-callback structs

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SteamNetworkingIdentity
    {
        public Int32 m_eType; // ESteamNetworkingIdentityType

        public Int32 m_cbSize;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string m_szUnknownRawString;
    }

    #endregion
}
