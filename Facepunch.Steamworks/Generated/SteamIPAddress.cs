using System.Runtime.InteropServices;

namespace Steamworks.Data;

partial struct SteamIPAddress {
    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamIPAddress_t_IsSet", CallingConvention = Platform.CC)]
    internal static extern bool InternalIsSet(ref SteamIPAddress self);
}