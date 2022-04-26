using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GameWebCallback_t : ICallbackData {
    internal string URLUTF8() {
        return Encoding.UTF8.GetString(URL, 0, Array.IndexOf<byte>(URL, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] // byte[] m_szURL
    internal byte[] URL; // m_szURL char [256]

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameWebCallback_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GameWebCallback;

#endregion
}
