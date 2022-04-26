using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data;

public partial struct NetAddress {
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_Clear", CallingConvention = Platform.CC)]
    internal static extern void InternalClear(ref NetAddress self);

    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsIPv6AllZeros", CallingConvention = Platform.CC)]
    internal static extern bool InternalIsIPv6AllZeros(ref NetAddress self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_SetIPv6", CallingConvention = Platform.CC)]
    internal static extern void InternalSetIPv6(ref NetAddress self, ref byte ipv6, ushort nPort);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_SetIPv4", CallingConvention = Platform.CC)]
    internal static extern void InternalSetIPv4(ref NetAddress self, uint nIP, ushort nPort);

    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsIPv4", CallingConvention = Platform.CC)]
    internal static extern bool InternalIsIPv4(ref NetAddress self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_GetIPv4", CallingConvention = Platform.CC)]
    internal static extern uint InternalGetIPv4(ref NetAddress self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_SetIPv6LocalHost", CallingConvention = Platform.CC)]
    internal static extern void InternalSetIPv6LocalHost(ref NetAddress self, ushort nPort);

    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsLocalHost", CallingConvention = Platform.CC)]
    internal static extern bool InternalIsLocalHost(ref NetAddress self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_ToString", CallingConvention = Platform.CC)]
    internal static extern void InternalToString(ref NetAddress self, IntPtr buf, uint cbBuf, [MarshalAs(UnmanagedType.U1)] bool bWithPort);

    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_ParseString", CallingConvention = Platform.CC)]
    internal static extern bool InternalParseString(ref NetAddress self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8StringToNative))] string pszStr);

    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsEqualTo", CallingConvention = Platform.CC)]
    internal static extern bool InternalIsEqualTo(ref NetAddress self, ref NetAddress x);
}