using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GlobalStatsReceived_t : ICallbackData {
    internal ulong GameID; // m_nGameID uint64
    internal Result Result; // m_eResult EResult

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GlobalStatsReceived_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GlobalStatsReceived;

#endregion
}