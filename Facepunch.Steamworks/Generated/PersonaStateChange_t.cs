using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct PersonaStateChange_t : ICallbackData {
    internal ulong SteamID; // m_ulSteamID uint64
    internal int ChangeFlags; // m_nChangeFlags int

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(PersonaStateChange_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.PersonaStateChange;

#endregion
}