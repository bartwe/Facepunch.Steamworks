using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LowBatteryPower_t : ICallbackData {
    internal byte MinutesBatteryLeft; // m_nMinutesBatteryLeft uint8

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LowBatteryPower_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.LowBatteryPower;

#endregion
}
