using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data;

public partial struct NetIdentity {
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_Clear", CallingConvention = Platform.CC)]
    internal static extern void InternalClear(ref NetIdentity self);

    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsInvalid", CallingConvention = Platform.CC)]
    internal static extern bool InternalIsInvalid(ref NetIdentity self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetSteamID", CallingConvention = Platform.CC)]
    internal static extern void InternalSetSteamID(ref NetIdentity self, SteamId steamID);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetSteamID", CallingConvention = Platform.CC)]
    internal static extern SteamId InternalGetSteamID(ref NetIdentity self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetSteamID64", CallingConvention = Platform.CC)]
    internal static extern void InternalSetSteamID64(ref NetIdentity self, ulong steamID);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetSteamID64", CallingConvention = Platform.CC)]
    internal static extern ulong InternalGetSteamID64(ref NetIdentity self);

    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetXboxPairwiseID", CallingConvention = Platform.CC)]
    internal static extern bool InternalSetXboxPairwiseID(ref NetIdentity self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8StringToNative))] string pszString);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetXboxPairwiseID", CallingConvention = Platform.CC)]
    internal static extern Utf8StringPointer InternalGetXboxPairwiseID(ref NetIdentity self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetPSNID", CallingConvention = Platform.CC)]
    internal static extern void InternalSetPSNID(ref NetIdentity self, ulong id);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetPSNID", CallingConvention = Platform.CC)]
    internal static extern ulong InternalGetPSNID(ref NetIdentity self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetStadiaID", CallingConvention = Platform.CC)]
    internal static extern void InternalSetStadiaID(ref NetIdentity self, ulong id);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetStadiaID", CallingConvention = Platform.CC)]
    internal static extern ulong InternalGetStadiaID(ref NetIdentity self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetIPAddr", CallingConvention = Platform.CC)]
    internal static extern void InternalSetIPAddr(ref NetIdentity self, ref NetAddress addr);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetIPAddr", CallingConvention = Platform.CC)]
    internal static extern IntPtr InternalGetIPAddr(ref NetIdentity self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetLocalHost", CallingConvention = Platform.CC)]
    internal static extern void InternalSetLocalHost(ref NetIdentity self);

    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsLocalHost", CallingConvention = Platform.CC)]
    internal static extern bool InternalIsLocalHost(ref NetIdentity self);

    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetGenericString", CallingConvention = Platform.CC)]
    internal static extern bool InternalSetGenericString(ref NetIdentity self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8StringToNative))] string pszString);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetGenericString", CallingConvention = Platform.CC)]
    internal static extern Utf8StringPointer InternalGetGenericString(ref NetIdentity self);

    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetGenericBytes", CallingConvention = Platform.CC)]
    internal static extern bool InternalSetGenericBytes(ref NetIdentity self, IntPtr data, uint cbLen);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetGenericBytes", CallingConvention = Platform.CC)]
    internal static extern byte InternalGetGenericBytes(ref NetIdentity self, ref int cbLen);

    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsEqualTo", CallingConvention = Platform.CC)]
    internal static extern bool InternalIsEqualTo(ref NetIdentity self, ref NetIdentity x);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_ToString", CallingConvention = Platform.CC)]
    internal static extern void InternalToString(ref NetIdentity self, IntPtr buf, uint cbBuf);

    [return: MarshalAs(UnmanagedType.I1)]
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_ParseString", CallingConvention = Platform.CC)]
    internal static extern bool InternalParseString(ref NetIdentity self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8StringToNative))] string pszStr);
}