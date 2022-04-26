using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GSReputation_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal uint ReputationScore; // m_unReputationScore uint32

    [MarshalAs(UnmanagedType.I1)]
    internal bool Banned; // m_bBanned bool

    internal uint BannedIP; // m_unBannedIP uint32
    internal ushort BannedPort; // m_usBannedPort uint16
    internal ulong BannedGameID; // m_ulBannedGameID uint64
    internal uint BanExpires; // m_unBanExpires uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSReputation_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GSReputation;

#endregion
}
