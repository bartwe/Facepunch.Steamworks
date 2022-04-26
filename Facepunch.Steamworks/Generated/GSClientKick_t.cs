using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GSClientKick_t : ICallbackData {
    internal ulong SteamID; // m_SteamID CSteamID
    internal DenyReason DenyReason; // m_eDenyReason EDenyReason

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSClientKick_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GSClientKick;

#endregion
}