using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamUGCRequestUGCDetailsResult_t : ICallbackData {
    internal SteamUGCDetails_t Details; // m_details SteamUGCDetails_t

    [MarshalAs(UnmanagedType.I1)]
    internal bool CachedData; // m_bCachedData bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamUGCRequestUGCDetailsResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamUGCRequestUGCDetailsResult;

#endregion
}
