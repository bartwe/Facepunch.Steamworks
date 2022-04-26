using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct ClientGameServerDeny_t : ICallbackData {
    internal uint AppID; // m_uAppID uint32
    internal uint GameServerIP; // m_unGameServerIP uint32
    internal ushort GameServerPort; // m_usGameServerPort uint16
    internal ushort Secure; // m_bSecure uint16
    internal uint Reason; // m_uReason uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ClientGameServerDeny_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.ClientGameServerDeny;

#endregion
}