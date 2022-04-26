using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct UserAchievementIconFetched_t : ICallbackData {
    internal GameId GameID; // m_nGameID CGameID

    internal string AchievementNameUTF8() {
        return Encoding.UTF8.GetString(AchievementName, 0, Array.IndexOf<byte>(AchievementName, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] // byte[] m_rgchAchievementName
    internal byte[] AchievementName; // m_rgchAchievementName char [128]

    [MarshalAs(UnmanagedType.I1)]
    internal bool Achieved; // m_bAchieved bool

    internal int IconHandle; // m_nIconHandle int

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(UserAchievementIconFetched_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.UserAchievementIconFetched;

#endregion
}
