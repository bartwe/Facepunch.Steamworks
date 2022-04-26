using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
partial struct servernetadr_t {
    internal ushort ConnectionPort; // m_usConnectionPort uint16
    internal ushort QueryPort; // m_usQueryPort uint16
    internal uint IP; // m_unIP uint32
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
partial struct gameserveritem_t {
    internal servernetadr_t NetAdr; // m_NetAdr servernetadr_t
    internal int Ping; // m_nPing int

    [MarshalAs(UnmanagedType.I1)]
    internal bool HadSuccessfulResponse; // m_bHadSuccessfulResponse bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool DoNotRefresh; // m_bDoNotRefresh bool

    internal string GameDirUTF8() {
        return Encoding.UTF8.GetString(GameDir, 0, Array.IndexOf<byte>(GameDir, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] // byte[] m_szGameDir
    internal byte[] GameDir; // m_szGameDir char [32]

    internal string MapUTF8() {
        return Encoding.UTF8.GetString(Map, 0, Array.IndexOf<byte>(Map, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] // byte[] m_szMap
    internal byte[] Map; // m_szMap char [32]

    internal string GameDescriptionUTF8() {
        return Encoding.UTF8.GetString(GameDescription, 0, Array.IndexOf<byte>(GameDescription, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] // byte[] m_szGameDescription
    internal byte[] GameDescription; // m_szGameDescription char [64]

    internal uint AppID; // m_nAppID uint32
    internal int Players; // m_nPlayers int
    internal int MaxPlayers; // m_nMaxPlayers int
    internal int BotPlayers; // m_nBotPlayers int

    [MarshalAs(UnmanagedType.I1)]
    internal bool Password; // m_bPassword bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool Secure; // m_bSecure bool

    internal uint TimeLastPlayed; // m_ulTimeLastPlayed uint32
    internal int ServerVersion; // m_nServerVersion int

    internal string ServerNameUTF8() {
        return Encoding.UTF8.GetString(ServerName, 0, Array.IndexOf<byte>(ServerName, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] // byte[] m_szServerName
    internal byte[] ServerName; // m_szServerName char [64]

    internal string GameTagsUTF8() {
        return Encoding.UTF8.GetString(GameTags, 0, Array.IndexOf<byte>(GameTags, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] // byte[] m_szGameTags
    internal byte[] GameTags; // m_szGameTags char [128]

    internal ulong SteamID; // m_steamID CSteamID
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
partial struct SteamNetworkingPOPIDRender {
    internal string BufUTF8() {
        return Encoding.UTF8.GetString(Buf, 0, Array.IndexOf<byte>(Buf, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] // byte[] buf
    internal byte[] Buf; // buf char [8]
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
partial struct NetIdentityRender {
    internal string BufUTF8() {
        return Encoding.UTF8.GetString(Buf, 0, Array.IndexOf<byte>(Buf, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] // byte[] buf
    internal byte[] Buf; // buf char [128]
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
partial struct NetAddressRender {
    internal string BufUTF8() {
        return Encoding.UTF8.GetString(Buf, 0, Array.IndexOf<byte>(Buf, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)] // byte[] buf
    internal byte[] Buf; // buf char [48]
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
partial struct SteamDatagramHostedAddress {
    internal int CbSize; // m_cbSize int

    internal string DataUTF8() {
        return Encoding.UTF8.GetString(Data, 0, Array.IndexOf<byte>(Data, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] // byte[] m_data
    internal byte[] Data; // m_data char [128]
}
