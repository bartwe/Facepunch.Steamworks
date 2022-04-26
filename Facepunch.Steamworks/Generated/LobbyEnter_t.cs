using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyEnter_t : ICallbackData {
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64
    internal uint GfChatPermissions; // m_rgfChatPermissions uint32

    [MarshalAs(UnmanagedType.I1)]
    internal bool Locked; // m_bLocked bool

    internal uint EChatRoomEnterResponse; // m_EChatRoomEnterResponse uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyEnter_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.LobbyEnter;

#endregion
}
