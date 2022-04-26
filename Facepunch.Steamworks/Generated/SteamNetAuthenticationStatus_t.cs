using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamNetAuthenticationStatus_t : ICallbackData {
    internal SteamNetworkingAvailability Avail; // m_eAvail ESteamNetworkingAvailability

    internal string DebugMsgUTF8() {
        return Encoding.UTF8.GetString(DebugMsg, 0, Array.IndexOf<byte>(DebugMsg, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] // byte[] m_debugMsg
    internal byte[] DebugMsg; // m_debugMsg char [256]

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamNetAuthenticationStatus_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamNetAuthenticationStatus;

#endregion
}