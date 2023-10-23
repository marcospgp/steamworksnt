using System;
using System.Runtime.InteropServices;

namespace Steamworksnt.SteamworksApi
{
    /// <param name="pchDebugText"> const char* </param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SteamAPIWarningMessageHook_t(Int32 nSeverity, IntPtr pchDebugText);
}
