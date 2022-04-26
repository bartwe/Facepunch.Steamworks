using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct FavoritesListAccountsUpdated_t : ICallbackData {
    internal Result Result; // m_eResult EResult

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(FavoritesListAccountsUpdated_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.FavoritesListAccountsUpdated;

#endregion
}
