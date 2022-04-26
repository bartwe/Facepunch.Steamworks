using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyGameCreated_t : ICallbackData {
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64
    internal ulong SteamIDGameServer; // m_ulSteamIDGameServer uint64
    internal uint IP; // m_unIP uint32
    internal ushort Port; // m_usPort uint16

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyGameCreated_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.LobbyGameCreated;

#endregion
}