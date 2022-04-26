using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GSClientApprove_t : ICallbackData {
    internal ulong SteamID; // m_SteamID CSteamID
    internal ulong OwnerSteamID; // m_OwnerSteamID CSteamID

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSClientApprove_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GSClientApprove;

#endregion
}