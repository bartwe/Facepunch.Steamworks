using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GSPolicyResponse_t : ICallbackData {
    internal byte Secure; // m_bSecure uint8

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSPolicyResponse_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GSPolicyResponse;

#endregion
}