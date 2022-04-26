using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct PSNGameBootInviteResult_t : ICallbackData {
    [MarshalAs(UnmanagedType.I1)]
    internal bool GameBootInviteExists; // m_bGameBootInviteExists bool

    internal ulong SteamIDLobby; // m_steamIDLobby CSteamID

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(PSNGameBootInviteResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.PSNGameBootInviteResult;

#endregion
}
