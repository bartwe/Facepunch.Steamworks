using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GSGameplayStats_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal int Rank; // m_nRank int32
    internal uint TotalConnects; // m_unTotalConnects uint32
    internal uint TotalMinutesPlayed; // m_unTotalMinutesPlayed uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSGameplayStats_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GSGameplayStats;

#endregion
}
