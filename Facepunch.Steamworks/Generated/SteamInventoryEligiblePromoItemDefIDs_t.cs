using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct SteamInventoryEligiblePromoItemDefIDs_t : ICallbackData {
    internal Result Result; // m_result EResult
    internal ulong SteamID; // m_steamID CSteamID
    internal int UmEligiblePromoItemDefs; // m_numEligiblePromoItemDefs int

    [MarshalAs(UnmanagedType.I1)]
    internal bool CachedData; // m_bCachedData bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamInventoryEligiblePromoItemDefIDs_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamInventoryEligiblePromoItemDefIDs;

#endregion
}
