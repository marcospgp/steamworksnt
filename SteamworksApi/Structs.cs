#pragma warning disable IDE1006 // Naming rule violations

using System;
using System.Runtime.InteropServices;

namespace Steamworksnt.SteamworksApi
{
    #region Callback structs

    /// <summary>
    /// General callback message struct.
    /// Comments included are from Steamworks SDK.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = Api.PLATFORM_STRUCT_PACK_SIZE)]
    public struct CallbackMsg_t
    {
        public Int32 m_hSteamUser; // Specific user to whom this callback applies.
        public Callback m_iCallback; // Callback identifier.  (Corresponds to the k_iCallback enum in the callback structure.)

        // Corresponds to "uint8 *m_pubParam".
        public IntPtr m_pubParam; // Points to the callback structure
        public Int32 m_cubParam; // Size of the data pointed to by m_pubParam
    };

    /// <summary>
    /// Asynchronous API call result struct.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = Api.PLATFORM_STRUCT_PACK_SIZE)]
    public struct SteamAPICallCompleted_t
    {
        public UInt64 m_hAsyncCall; // UInt64 corresponds to SteamAPICall_t.
        public Int32 m_iCallback;
        public UInt32 m_cubParam;
    }

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
