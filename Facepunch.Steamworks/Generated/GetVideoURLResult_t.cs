using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GetVideoURLResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal AppId VideoAppID; // m_unVideoAppID AppId_t

    internal string URLUTF8() {
        return Encoding.UTF8.GetString(URL, 0, Array.IndexOf<byte>(URL, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] // byte[] m_rgchURL
    internal byte[] URL; // m_rgchURL char [256]

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GetVideoURLResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GetVideoURLResult;

#endregion
}
