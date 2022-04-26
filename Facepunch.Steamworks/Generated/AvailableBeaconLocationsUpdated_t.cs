using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct AvailableBeaconLocationsUpdated_t : ICallbackData {
#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(AvailableBeaconLocationsUpdated_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.AvailableBeaconLocationsUpdated;

#endregion
}