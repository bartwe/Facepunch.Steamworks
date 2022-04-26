using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamServerConnectFailure_t : ICallbackData {
    internal Result Result; // m_eResult EResult

    [MarshalAs(UnmanagedType.I1)]
    internal bool StillRetrying; // m_bStillRetrying bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamServerConnectFailure_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamServerConnectFailure;

#endregion
}