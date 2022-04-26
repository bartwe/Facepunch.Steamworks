using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct FavoritesListChanged_t : ICallbackData {
    internal uint IP; // m_nIP uint32
    internal uint QueryPort; // m_nQueryPort uint32
    internal uint ConnPort; // m_nConnPort uint32
    internal uint AppID; // m_nAppID uint32
    internal uint Flags; // m_nFlags uint32

    [MarshalAs(UnmanagedType.I1)]
    internal bool Add; // m_bAdd bool

    internal uint AccountId; // m_unAccountId AccountID_t

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(FavoritesListChanged_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.FavoritesListChanged;

#endregion
}