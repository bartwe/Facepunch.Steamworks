using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GameConnectedChatLeave_t : ICallbackData {
    internal ulong SteamIDClanChat; // m_steamIDClanChat CSteamID
    internal ulong SteamIDUser; // m_steamIDUser CSteamID

    [MarshalAs(UnmanagedType.I1)]
    internal bool Kicked; // m_bKicked bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool Dropped; // m_bDropped bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameConnectedChatLeave_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GameConnectedChatLeave;

#endregion
}
