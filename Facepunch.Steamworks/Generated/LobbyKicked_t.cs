using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyKicked_t : ICallbackData {
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64
    internal ulong SteamIDAdmin; // m_ulSteamIDAdmin uint64
    internal byte KickedDueToDisconnect; // m_bKickedDueToDisconnect uint8

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyKicked_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.LobbyKicked;

#endregion
}
