using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GameServerChangeRequested_t : ICallbackData {
    internal string ServerUTF8() {
        return Encoding.UTF8.GetString(Server, 0, Array.IndexOf<byte>(Server, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] // byte[] m_rgchServer
    internal byte[] Server; // m_rgchServer char [64]

    internal string PasswordUTF8() {
        return Encoding.UTF8.GetString(Password, 0, Array.IndexOf<byte>(Password, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] // byte[] m_rgchPassword
    internal byte[] Password; // m_rgchPassword char [64]

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameServerChangeRequested_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GameServerChangeRequested;

#endregion
}