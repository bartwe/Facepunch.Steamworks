using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamInventoryResultReady_t : ICallbackData {
    internal int Handle; // m_handle SteamInventoryResult_t
    internal Result Result; // m_result EResult

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamInventoryResultReady_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamInventoryResultReady;

#endregion
}
