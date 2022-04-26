using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamInventoryStartPurchaseResult_t : ICallbackData {
    internal Result Result; // m_result EResult
    internal ulong OrderID; // m_ulOrderID uint64
    internal ulong TransID; // m_ulTransID uint64

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamInventoryStartPurchaseResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamInventoryStartPurchaseResult;

#endregion
}