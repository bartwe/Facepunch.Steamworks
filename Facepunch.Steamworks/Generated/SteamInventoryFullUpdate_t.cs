using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamInventoryFullUpdate_t : ICallbackData {
    internal int Handle; // m_handle SteamInventoryResult_t

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamInventoryFullUpdate_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamInventoryFullUpdate;

#endregion
}