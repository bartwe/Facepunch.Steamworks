using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LeaderboardFindResult_t : ICallbackData {
    internal ulong SteamLeaderboard; // m_hSteamLeaderboard SteamLeaderboard_t
    internal byte LeaderboardFound; // m_bLeaderboardFound uint8

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LeaderboardFindResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.LeaderboardFindResult;

#endregion
}