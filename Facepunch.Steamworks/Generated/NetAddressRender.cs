using System.Runtime.InteropServices;

namespace Steamworks.Data;

partial struct NetAddressRender {
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddrRender_c_str", CallingConvention = Platform.CC)]
    internal static extern Utf8StringPointer Internalc_str(ref NetAddressRender self);
}