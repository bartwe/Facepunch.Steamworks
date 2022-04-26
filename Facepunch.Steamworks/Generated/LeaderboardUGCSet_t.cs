using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LeaderboardUGCSet_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong SteamLeaderboard; // m_hSteamLeaderboard SteamLeaderboard_t

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LeaderboardUGCSet_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.LeaderboardUGCSet;

#endregion
}