using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct UserAchievementStored_t : ICallbackData {
    internal ulong GameID; // m_nGameID uint64

    [MarshalAs(UnmanagedType.I1)]
    internal bool GroupAchievement; // m_bGroupAchievement bool

    internal string AchievementNameUTF8() {
        return Encoding.UTF8.GetString(AchievementName, 0, Array.IndexOf<byte>(AchievementName, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] // byte[] m_rgchAchievementName
    internal byte[] AchievementName; // m_rgchAchievementName char [128]

    internal uint CurProgress; // m_nCurProgress uint32
    internal uint MaxProgress; // m_nMaxProgress uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(UserAchievementStored_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.UserAchievementStored;

#endregion
}
