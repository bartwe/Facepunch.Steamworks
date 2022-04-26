using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct ClanOfficerListResponse_t : ICallbackData {
    internal ulong SteamIDClan; // m_steamIDClan CSteamID
    internal int COfficers; // m_cOfficers int
    internal byte Success; // m_bSuccess uint8

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ClanOfficerListResponse_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.ClanOfficerListResponse;

#endregion
}
