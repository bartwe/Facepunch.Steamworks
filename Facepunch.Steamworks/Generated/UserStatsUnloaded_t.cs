using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct UserStatsUnloaded_t : ICallbackData {
    internal ulong SteamIDUser; // m_steamIDUser CSteamID

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(UserStatsUnloaded_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.UserStatsUnloaded;

#endregion
}
