using System.Runtime.InteropServices;

namespace Steamworks.Data;

partial struct servernetadr_t {
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_Construct", CallingConvention = Platform.CC)]
    internal static extern void InternalConstruct(ref servernetadr_t self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_Init", CallingConvention = Platform.CC)]
    internal static extern void InternalInit(ref servernetadr_t self, uint ip, ushort usQueryPort, ushort usConnectionPort);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetQueryPort", CallingConvention = Platform.CC)]
    internal static extern ushort InternalGetQueryPort(ref servernetadr_t self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_SetQueryPort", CallingConvention = Platform.CC)]
    internal static extern void InternalSetQueryPort(ref servernetadr_t self, ushort usPort);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetConnectionPort", CallingConvention = Platform.CC)]
    internal static extern ushort InternalGetConnectionPort(ref servernetadr_t self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_SetConnectionPort", CallingConvention = Platform.CC)]
    internal static extern void InternalSetConnectionPort(ref servernetadr_t self, ushort usPort);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetIP", CallingConvention = Platform.CC)]
    internal static extern uint InternalGetIP(ref servernetadr_t self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_SetIP", CallingConvention = Platform.CC)]
    internal static extern void InternalSetIP(ref servernetadr_t self, uint unIP);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetConnectionAddressString", CallingConvention = Platform.CC)]
    internal static extern Utf8StringPointer InternalGetConnectionAddressString(ref servernetadr_t self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetQueryAddressString", CallingConvention = Platform.CC)]
    internal static extern Utf8StringPointer InternalGetQueryAddressString(ref servernetadr_t self);

    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_IsLessThan", CallingConvention = Platform.CC)]
    internal static extern bool InternalIsLessThan(ref servernetadr_t self, ref servernetadr_t netadr);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_Assign", CallingConvention = Platform.CC)]
    internal static extern void InternalAssign(ref servernetadr_t self, ref servernetadr_t that);
}
