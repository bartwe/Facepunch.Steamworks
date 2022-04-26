using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LeaderboardScoreUploaded_t : ICallbackData {
    internal byte Success; // m_bSuccess uint8
    internal ulong SteamLeaderboard; // m_hSteamLeaderboard SteamLeaderboard_t
    internal int Score; // m_nScore int32
    internal byte ScoreChanged; // m_bScoreChanged uint8
    internal int GlobalRankNew; // m_nGlobalRankNew int
    internal int GlobalRankPrevious; // m_nGlobalRankPrevious int

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LeaderboardScoreUploaded_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.LeaderboardScoreUploaded;

#endregion
}