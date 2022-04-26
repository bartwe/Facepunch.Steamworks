using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct CheckFileSignature_t : ICallbackData {
    internal CheckFileSignature CheckFileSignature; // m_eCheckFileSignature ECheckFileSignature

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(CheckFileSignature_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.CheckFileSignature;

#endregion
}