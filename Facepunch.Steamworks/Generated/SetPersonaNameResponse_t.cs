using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SetPersonaNameResponse_t : ICallbackData {
    [MarshalAs(UnmanagedType.I1)]
    internal bool Success; // m_bSuccess bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool LocalSuccess; // m_bLocalSuccess bool

    internal Result Result; // m_result EResult

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SetPersonaNameResponse_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SetPersonaNameResponse;

#endregion
}
