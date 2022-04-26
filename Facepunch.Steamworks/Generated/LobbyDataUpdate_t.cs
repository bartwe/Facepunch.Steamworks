using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyDataUpdate_t : ICallbackData {
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64
    internal ulong SteamIDMember; // m_ulSteamIDMember uint64
    internal byte Success; // m_bSuccess uint8

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyDataUpdate_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.LobbyDataUpdate;

#endregion
}
