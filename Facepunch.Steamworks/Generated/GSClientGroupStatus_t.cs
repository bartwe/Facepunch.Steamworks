using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GSClientGroupStatus_t : ICallbackData {
    internal ulong SteamIDUser; // m_SteamIDUser CSteamID
    internal ulong SteamIDGroup; // m_SteamIDGroup CSteamID

    [MarshalAs(UnmanagedType.I1)]
    internal bool Member; // m_bMember bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool Officer; // m_bOfficer bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSClientGroupStatus_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GSClientGroupStatus;

#endregion
}
