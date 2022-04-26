using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GlobalAchievementPercentagesReady_t : ICallbackData {
    internal ulong GameID; // m_nGameID uint64
    internal Result Result; // m_eResult EResult

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GlobalAchievementPercentagesReady_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GlobalAchievementPercentagesReady;

#endregion
}
