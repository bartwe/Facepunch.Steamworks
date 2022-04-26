using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LeaderboardEntry_t {
    internal ulong SteamIDUser; // m_steamIDUser CSteamID
    internal int GlobalRank; // m_nGlobalRank int32
    internal int Score; // m_nScore int32
    internal int CDetails; // m_cDetails int32
    internal ulong UGC; // m_hUGC UGCHandle_t
}