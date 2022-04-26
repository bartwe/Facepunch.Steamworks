using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GetAuthSessionTicketResponse_t : ICallbackData {
    internal uint AuthTicket; // m_hAuthTicket HAuthTicket
    internal Result Result; // m_eResult EResult

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GetAuthSessionTicketResponse_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GetAuthSessionTicketResponse;

#endregion
}
