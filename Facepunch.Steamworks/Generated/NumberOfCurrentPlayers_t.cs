using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct NumberOfCurrentPlayers_t : ICallbackData {
    internal byte Success; // m_bSuccess uint8
    internal int CPlayers; // m_cPlayers int32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(NumberOfCurrentPlayers_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.NumberOfCurrentPlayers;

#endregion
}