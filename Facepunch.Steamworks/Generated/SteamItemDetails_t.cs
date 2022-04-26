using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamItemDetails_t {
    internal InventoryItemId ItemId; // m_itemId SteamItemInstanceID_t
    internal InventoryDefId Definition; // m_iDefinition SteamItemDef_t
    internal ushort Quantity; // m_unQuantity uint16
    internal ushort Flags; // m_unFlags uint16
}
