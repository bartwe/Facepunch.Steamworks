using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct ReservationNotificationCallback_t : ICallbackData {
    internal ulong BeaconID; // m_ulBeaconID PartyBeaconID_t
    internal ulong SteamIDJoiner; // m_steamIDJoiner CSteamID

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ReservationNotificationCallback_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.ReservationNotificationCallback;

#endregion
}
