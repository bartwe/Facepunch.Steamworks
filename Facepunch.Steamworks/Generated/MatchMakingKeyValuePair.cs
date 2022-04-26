using System.Runtime.InteropServices;

namespace Steamworks.Data;

partial struct MatchMakingKeyValuePair {
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_MatchMakingKeyValuePair_t_Construct", CallingConvention = Platform.CC)]
    internal static extern void InternalConstruct(ref MatchMakingKeyValuePair self);
}
