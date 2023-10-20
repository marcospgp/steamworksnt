#pragma warning disable IDE1006 // Naming rule violations

using System;
using System.Runtime.InteropServices;

namespace Steamworksnt.SteamworksApi
{
    public static class Api
    {
        #region Platform

#if (UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN) && !UNITY_64
        private const string DLL_FILENAME = "steam_api";
        public const int PLATFORM_STRUCT_PACK_SIZE = 8;
#elif (UNITY_EDITOR_LINUX || UNITY_STANDALONE_LINUX || UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX)
        public const int PLATFORM_STRUCT_PACK_SIZE = 4;
        private const string DLL_FILENAME = "libsteam_api";
#else
        // Default to 64-bit Windows.
        private const string DLL_FILENAME = "steam_api64";
        public const int PLATFORM_STRUCT_PACK_SIZE = 8;
#endif

        // Facepunch Steamworks has this, not yet sure where or why it is used.
        // private const int STRUCT_PACK_SIZE = 4;

        #endregion

        #region Initialization

        /// <returns> HSteamPipe </returns>
        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 SteamAPI_GetHSteamPipe();

        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool SteamAPI_IsSteamRunning();

        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool SteamAPI_Init();

        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SteamAPI_Shutdown();

        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool SteamAPI_RestartAppIfNecessary();

        #endregion

        #region ManualDispatch (callbacks)

        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SteamAPI_ManualDispatch_Init();

        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SteamAPI_ManualDispatch_RunFrame(Int32 hSteamPipe);

        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SteamAPI_ManualDispatch_GetNextCallback(
            Int32 hSteamPipe,
            ref CallbackMsg_t msg
        );

        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SteamAPI_ManualDispatch_FreeLastCallback(Int32 hSteamPipe);

        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool SteamAPI_ManualDispatch_GetAPICallResult(
            Int32 hSteamPipe,
            UInt64 hSteamAPICall,
            IntPtr pCallback,
            Int32 cubCallback,
            Callback iCallbackExpected,
            [MarshalAs(UnmanagedType.U1)] ref bool pbFailed
        );

        #endregion

        #region SteamNetworkingUtils

        /// <returns> ISteamNetworkingUtils* </returns>
        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SteamAPI_SteamNetworkingUtils_SteamAPI_v004();

        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SteamAPI_ISteamNetworkingUtils_InitRelayNetworkAccess(
            IntPtr iSteamNetworkingUtils
        );

        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern ESteamNetworkingAvailability SteamAPI_ISteamNetworkingUtils_GetRelayNetworkStatus(
            IntPtr iSteamNetworkingUtils,
            ref SteamRelayNetworkStatus_t pDetails
        );

        #endregion

        #region SteamNetworkingMessages

        /// <returns> ISteamNetworkingMessages* </returns>
        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SteamAPI_SteamNetworkingMessages_SteamAPI_v002();

        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern EResult SteamAPI_ISteamNetworkingMessages_SendMessageToUser(
            IntPtr iSteamNetworkingMessages, // self
            in SteamNetworkingIdentity identityRemote,
            byte[] pubData, // Data to send
            UInt32 cubData, // Size of data to send
            Int32 nSendFlags,
            Int32 nRemoteChannel
        );

        #endregion

        #region SteamUserStats

        /// <returns> ISteamUserStats* </returns>
        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SteamAPI_SteamUserStats_v012();

        [DllImport(DLL_FILENAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SteamAPI_ISteamUserStats_RequestCurrentStats(
            IntPtr iSteamUserStats
        );

        #endregion
    }
}
