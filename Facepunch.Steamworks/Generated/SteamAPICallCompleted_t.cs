using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamAPICallCompleted_t : ICallbackData {
    internal ulong AsyncCall; // m_hAsyncCall SteamAPICall_t
    internal int Callback; // m_iCallback int
    internal uint ParamCount; // m_cubParam uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamAPICallCompleted_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamAPICallCompleted;

#endregion
}
