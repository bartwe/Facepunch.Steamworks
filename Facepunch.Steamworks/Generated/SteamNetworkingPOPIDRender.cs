using System.Runtime.InteropServices;

namespace Steamworks.Data;

partial struct SteamNetworkingPOPIDRender {
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingPOPIDRender_c_str", CallingConvention = Platform.CC)]
    internal static extern Utf8StringPointer Internalc_str(ref SteamNetworkingPOPIDRender self);
}