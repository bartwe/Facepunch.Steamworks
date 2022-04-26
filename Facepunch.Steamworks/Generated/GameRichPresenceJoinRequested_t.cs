using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GameRichPresenceJoinRequested_t : ICallbackData {
    internal ulong SteamIDFriend; // m_steamIDFriend CSteamID

    internal string ConnectUTF8() {
        return Encoding.UTF8.GetString(Connect, 0, Array.IndexOf<byte>(Connect, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] // byte[] m_rgchConnect
    internal byte[] Connect; // m_rgchConnect char [256]

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameRichPresenceJoinRequested_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GameRichPresenceJoinRequested;

#endregion
}
