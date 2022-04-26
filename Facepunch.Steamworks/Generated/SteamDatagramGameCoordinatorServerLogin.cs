using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamDatagramGameCoordinatorServerLogin {
    internal NetIdentity Dentity; // m_identity SteamNetworkingIdentity
    internal SteamDatagramHostedAddress Outing; // m_routing SteamDatagramHostedAddress
    internal AppId AppID; // m_nAppID AppId_t
    internal uint Time; // m_rtime RTime32
    internal int CbAppData; // m_cbAppData int

    internal string AppDataUTF8() {
        return Encoding.UTF8.GetString(AppData, 0, Array.IndexOf<byte>(AppData, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)] // byte[] m_appData
    internal byte[] AppData; // m_appData char [2048]
}
