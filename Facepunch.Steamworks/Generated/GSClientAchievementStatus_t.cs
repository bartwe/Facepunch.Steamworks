using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GSClientAchievementStatus_t : ICallbackData {
    internal ulong SteamID; // m_SteamID uint64

    internal string PchAchievementUTF8() {
        return Encoding.UTF8.GetString(PchAchievement, 0, Array.IndexOf<byte>(PchAchievement, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] // byte[] m_pchAchievement
    internal byte[] PchAchievement; // m_pchAchievement char [128]

    [MarshalAs(UnmanagedType.I1)]
    internal bool Unlocked; // m_bUnlocked bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSClientAchievementStatus_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GSClientAchievementStatus;

#endregion
}
