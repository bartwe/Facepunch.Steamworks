using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct UserStatsReceived_t : ICallbackData {
    internal ulong GameID; // m_nGameID uint64
    internal Result Result; // m_eResult EResult
    internal ulong SteamIDUser; // m_steamIDUser CSteamID

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(UserStatsReceived_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.UserStatsReceived;

#endregion
}
