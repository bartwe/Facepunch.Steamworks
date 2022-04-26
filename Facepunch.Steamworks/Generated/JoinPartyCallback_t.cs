using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct JoinPartyCallback_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong BeaconID; // m_ulBeaconID PartyBeaconID_t
    internal ulong SteamIDBeaconOwner; // m_SteamIDBeaconOwner CSteamID

    internal string ConnectStringUTF8() {
        return Encoding.UTF8.GetString(ConnectString, 0, Array.IndexOf<byte>(ConnectString, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] // byte[] m_rgchConnectString
    internal byte[] ConnectString; // m_rgchConnectString char [256]

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(JoinPartyCallback_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.JoinPartyCallback;

#endregion
}