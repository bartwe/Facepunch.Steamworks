using System.Runtime.InteropServices;

namespace Steamworks.Data;

partial struct NetIdentityRender {
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentityRender_c_str", CallingConvention = Platform.CC)]
    internal static extern Utf8StringPointer Internalc_str(ref NetIdentityRender self);
}
