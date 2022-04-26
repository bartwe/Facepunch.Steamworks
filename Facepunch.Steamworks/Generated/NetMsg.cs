using System.Runtime.InteropServices;

namespace Steamworks.Data;

partial struct NetMsg {
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingMessage_t_Release", CallingConvention = Platform.CC)]
    internal static extern unsafe void InternalRelease(NetMsg* self);
}
