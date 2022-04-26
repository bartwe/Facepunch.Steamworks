using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GSClientDeny_t : ICallbackData {
    internal ulong SteamID; // m_SteamID CSteamID
    internal DenyReason DenyReason; // m_eDenyReason EDenyReason

    internal string OptionalTextUTF8() {
        return Encoding.UTF8.GetString(OptionalText, 0, Array.IndexOf<byte>(OptionalText, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] // byte[] m_rgchOptionalText
    internal byte[] OptionalText; // m_rgchOptionalText char [128]

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSClientDeny_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GSClientDeny;

#endregion
}