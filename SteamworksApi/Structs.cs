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
        /// Summary status.  When this is "current", initialization has
        /// completed.  Anything else means you are not ready yet, or
        /// there is a significant problem.
        public ESteamNetworkingAvailability m_eAvail;

        /// Nonzero if latency measurement is in progress (or pending,
        /// awaiting a prerequisite).
        public Int32 m_bPingMeasurementInProgress;

        /// Status obtaining the network config.  This is a prerequisite
        /// for relay network access.
        ///
        /// Failure to obtain the network config almost always indicates
        /// a problem with the local internet connection.
        public ESteamNetworkingAvailability m_eAvailNetworkConfig;

        /// Current ability to communicate with ANY relay.  Note that
        /// the complete failure to communicate with any relays almost
        /// always indicates a problem with the local Internet connection.
        /// (However, just because you can reach a single relay doesn't
        /// mean that the local connection is in perfect health.)
        public ESteamNetworkingAvailability m_eAvailAnyRelay;

        /// Non-localized English language status.  For diagnostic/debugging
        /// purposes only.

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
