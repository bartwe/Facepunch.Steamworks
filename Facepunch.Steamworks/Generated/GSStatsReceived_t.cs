using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GSStatsReceived_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong SteamIDUser; // m_steamIDUser CSteamID

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSStatsReceived_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GSStatsReceived;

#endregion
}
