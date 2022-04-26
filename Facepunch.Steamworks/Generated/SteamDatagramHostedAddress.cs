using System.Runtime.InteropServices;

namespace Steamworks.Data;

partial struct SteamDatagramHostedAddress {
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamDatagramHostedAddress_Clear", CallingConvention = Platform.CC)]
    internal static extern void InternalClear(ref SteamDatagramHostedAddress self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamDatagramHostedAddress_GetPopID", CallingConvention = Platform.CC)]
    internal static extern SteamNetworkingPOPID InternalGetPopID(ref SteamDatagramHostedAddress self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_SteamDatagramHostedAddress_SetDevAddress", CallingConvention = Platform.CC)]
    internal static extern void InternalSetDevAddress(ref SteamDatagramHostedAddress self, uint nIP, ushort nPort, SteamNetworkingPOPID popid);
}
