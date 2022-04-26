using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamNetworkingMessagesSessionRequest_t : ICallbackData {
    internal NetIdentity DentityRemote; // m_identityRemote SteamNetworkingIdentity

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamNetworkingMessagesSessionRequest_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamNetworkingMessagesSessionRequest;

#endregion
}