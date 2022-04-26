using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamPartyBeaconLocation_t {
    internal SteamPartyBeaconLocationType Type; // m_eType ESteamPartyBeaconLocationType
    internal ulong LocationID; // m_ulLocationID uint64
}
