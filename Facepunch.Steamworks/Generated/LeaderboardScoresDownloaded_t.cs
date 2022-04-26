using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LeaderboardScoresDownloaded_t : ICallbackData {
    internal ulong SteamLeaderboard; // m_hSteamLeaderboard SteamLeaderboard_t
    internal ulong SteamLeaderboardEntries; // m_hSteamLeaderboardEntries SteamLeaderboardEntries_t
    internal int CEntryCount; // m_cEntryCount int

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LeaderboardScoresDownloaded_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.LeaderboardScoresDownloaded;

#endregion
}
