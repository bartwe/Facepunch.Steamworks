using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct P2PSessionState_t {
    internal byte ConnectionActive; // m_bConnectionActive uint8
    internal byte Connecting; // m_bConnecting uint8
    internal byte P2PSessionError; // m_eP2PSessionError uint8
    internal byte UsingRelay; // m_bUsingRelay uint8
    internal int BytesQueuedForSend; // m_nBytesQueuedForSend int32
    internal int PacketsQueuedForSend; // m_nPacketsQueuedForSend int32
    internal uint RemoteIP; // m_nRemoteIP uint32
    internal ushort RemotePort; // m_nRemotePort uint16
}