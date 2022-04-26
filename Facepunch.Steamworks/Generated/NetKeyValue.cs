using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data;

partial struct NetKeyValue {
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetInt32", CallingConvention = Platform.CC)]
    internal static extern void InternalSetInt32(ref NetKeyValue self, NetConfig eVal, int data);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetInt64", CallingConvention = Platform.CC)]
    internal static extern void InternalSetInt64(ref NetKeyValue self, NetConfig eVal, long data);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetFloat", CallingConvention = Platform.CC)]
    internal static extern void InternalSetFloat(ref NetKeyValue self, NetConfig eVal, float data);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetPtr", CallingConvention = Platform.CC)]
    internal static extern void InternalSetPtr(ref NetKeyValue self, NetConfig eVal, IntPtr data);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetString", CallingConvention = Platform.CC)]
    internal static extern void InternalSetString(ref NetKeyValue self, NetConfig eVal, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8StringToNative))] string data);
}
