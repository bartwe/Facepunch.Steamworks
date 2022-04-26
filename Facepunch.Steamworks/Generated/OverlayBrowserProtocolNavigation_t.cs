using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct OverlayBrowserProtocolNavigation_t : ICallbackData {
    internal string RgchURIUTF8() {
        return Encoding.UTF8.GetString(RgchURI, 0, Array.IndexOf<byte>(RgchURI, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)] // byte[] rgchURI
    internal byte[] RgchURI; // rgchURI char [1024]

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(OverlayBrowserProtocolNavigation_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.OverlayBrowserProtocolNavigation;

#endregion
}