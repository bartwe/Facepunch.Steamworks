using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamServersConnected_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamServersConnected_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamServersConnected; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamServerConnectFailure_t : ICallbackData {
    internal Result Result; // m_eResult EResult

    [MarshalAs(UnmanagedType.I1)]
    internal bool StillRetrying; // m_bStillRetrying bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamServerConnectFailure_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamServerConnectFailure; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamServersDisconnected_t : ICallbackData {
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamServersDisconnected_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamServersDisconnected; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct ClientGameServerDeny_t : ICallbackData {
    internal uint AppID; // m_uAppID uint32
    internal uint GameServerIP; // m_unGameServerIP uint32
    internal ushort GameServerPort; // m_usGameServerPort uint16
    internal ushort Secure; // m_bSecure uint16
    internal uint Reason; // m_uReason uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ClientGameServerDeny_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.ClientGameServerDeny; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct IPCFailure_t : ICallbackData {
    internal byte FailureType; // m_eFailureType uint8

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(IPCFailure_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.IPCFailure; }
    }

    #endregion

    internal enum EFailureType {
        FlushedCallbackQueue = 0,
        PipeFail = 1,
    }
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LicensesUpdated_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LicensesUpdated_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LicensesUpdated; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct ValidateAuthTicketResponse_t : ICallbackData {
    internal ulong SteamID; // m_SteamID CSteamID
    internal AuthResponse AuthSessionResponse; // m_eAuthSessionResponse EAuthSessionResponse
    internal ulong OwnerSteamID; // m_OwnerSteamID CSteamID

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ValidateAuthTicketResponse_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.ValidateAuthTicketResponse; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MicroTxnAuthorizationResponse_t : ICallbackData {
    internal uint AppID; // m_unAppID uint32
    internal ulong OrderID; // m_ulOrderID uint64
    internal byte Authorized; // m_bAuthorized uint8

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MicroTxnAuthorizationResponse_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MicroTxnAuthorizationResponse; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct EncryptedAppTicketResponse_t : ICallbackData {
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(EncryptedAppTicketResponse_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.EncryptedAppTicketResponse; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GetAuthSessionTicketResponse_t : ICallbackData {
    internal uint AuthTicket; // m_hAuthTicket HAuthTicket
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GetAuthSessionTicketResponse_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GetAuthSessionTicketResponse; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GameWebCallback_t : ICallbackData {
    internal string URLUTF8() {
        return Encoding.UTF8.GetString(URL, 0, Array.IndexOf<byte>(URL, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] // byte[] m_szURL
    internal byte[] URL; // m_szURL char [256]

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameWebCallback_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GameWebCallback; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct StoreAuthURLResponse_t : ICallbackData {
    internal string URLUTF8() {
        return Encoding.UTF8.GetString(URL, 0, Array.IndexOf<byte>(URL, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)] // byte[] m_szURL
    internal byte[] URL; // m_szURL char [512]

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(StoreAuthURLResponse_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.StoreAuthURLResponse; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MarketEligibilityResponse_t : ICallbackData {
    [MarshalAs(UnmanagedType.I1)]
    internal bool Allowed; // m_bAllowed bool

    internal MarketNotAllowedReasonFlags NotAllowedReason; // m_eNotAllowedReason EMarketNotAllowedReasonFlags
    internal uint TAllowedAtTime; // m_rtAllowedAtTime RTime32
    internal int CdaySteamGuardRequiredDays; // m_cdaySteamGuardRequiredDays int
    internal int CdayNewDeviceCooldown; // m_cdayNewDeviceCooldown int

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MarketEligibilityResponse_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MarketEligibilityResponse; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct DurationControl_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal AppId Appid; // m_appid AppId_t

    [MarshalAs(UnmanagedType.I1)]
    internal bool Applicable; // m_bApplicable bool

    internal int CsecsLast5h; // m_csecsLast5h int32
    internal DurationControlProgress Progress; // m_progress EDurationControlProgress
    internal DurationControlNotification Otification; // m_notification EDurationControlNotification
    internal int CsecsToday; // m_csecsToday int32
    internal int CsecsRemaining; // m_csecsRemaining int32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(DurationControl_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.DurationControl; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct PersonaStateChange_t : ICallbackData {
    internal ulong SteamID; // m_ulSteamID uint64
    internal int ChangeFlags; // m_nChangeFlags int

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(PersonaStateChange_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.PersonaStateChange; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GameOverlayActivated_t : ICallbackData {
    internal byte Active; // m_bActive uint8

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameOverlayActivated_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GameOverlayActivated; }
    }

    #endregion
}

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

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GameServerChangeRequested; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GameLobbyJoinRequested_t : ICallbackData {
    internal ulong SteamIDLobby; // m_steamIDLobby CSteamID
    internal ulong SteamIDFriend; // m_steamIDFriend CSteamID

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameLobbyJoinRequested_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GameLobbyJoinRequested; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct AvatarImageLoaded_t : ICallbackData {
    internal ulong SteamID; // m_steamID CSteamID
    internal int Image; // m_iImage int
    internal int Wide; // m_iWide int
    internal int Tall; // m_iTall int

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(AvatarImageLoaded_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.AvatarImageLoaded; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct ClanOfficerListResponse_t : ICallbackData {
    internal ulong SteamIDClan; // m_steamIDClan CSteamID
    internal int COfficers; // m_cOfficers int
    internal byte Success; // m_bSuccess uint8

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ClanOfficerListResponse_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.ClanOfficerListResponse; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct FriendRichPresenceUpdate_t : ICallbackData {
    internal ulong SteamIDFriend; // m_steamIDFriend CSteamID
    internal AppId AppID; // m_nAppID AppId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(FriendRichPresenceUpdate_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.FriendRichPresenceUpdate; }
    }

    #endregion
}

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

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GameRichPresenceJoinRequested; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GameConnectedClanChatMsg_t : ICallbackData {
    internal ulong SteamIDClanChat; // m_steamIDClanChat CSteamID
    internal ulong SteamIDUser; // m_steamIDUser CSteamID
    internal int MessageID; // m_iMessageID int

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameConnectedClanChatMsg_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GameConnectedClanChatMsg; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GameConnectedChatJoin_t : ICallbackData {
    internal ulong SteamIDClanChat; // m_steamIDClanChat CSteamID
    internal ulong SteamIDUser; // m_steamIDUser CSteamID

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameConnectedChatJoin_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GameConnectedChatJoin; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GameConnectedChatLeave_t : ICallbackData {
    internal ulong SteamIDClanChat; // m_steamIDClanChat CSteamID
    internal ulong SteamIDUser; // m_steamIDUser CSteamID

    [MarshalAs(UnmanagedType.I1)]
    internal bool Kicked; // m_bKicked bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool Dropped; // m_bDropped bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameConnectedChatLeave_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GameConnectedChatLeave; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct DownloadClanActivityCountsResult_t : ICallbackData {
    [MarshalAs(UnmanagedType.I1)]
    internal bool Success; // m_bSuccess bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(DownloadClanActivityCountsResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.DownloadClanActivityCountsResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct JoinClanChatRoomCompletionResult_t : ICallbackData {
    internal ulong SteamIDClanChat; // m_steamIDClanChat CSteamID
    internal RoomEnter ChatRoomEnterResponse; // m_eChatRoomEnterResponse EChatRoomEnterResponse

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(JoinClanChatRoomCompletionResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.JoinClanChatRoomCompletionResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GameConnectedFriendChatMsg_t : ICallbackData {
    internal ulong SteamIDUser; // m_steamIDUser CSteamID
    internal int MessageID; // m_iMessageID int

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameConnectedFriendChatMsg_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GameConnectedFriendChatMsg; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct FriendsGetFollowerCount_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong SteamID; // m_steamID CSteamID
    internal int Count; // m_nCount int

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(FriendsGetFollowerCount_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.FriendsGetFollowerCount; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct FriendsIsFollowing_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong SteamID; // m_steamID CSteamID

    [MarshalAs(UnmanagedType.I1)]
    internal bool IsFollowing; // m_bIsFollowing bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(FriendsIsFollowing_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.FriendsIsFollowing; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct FriendsEnumerateFollowingList_t : ICallbackData {
    internal Result Result; // m_eResult EResult

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
    internal ulong[] GSteamID; // m_rgSteamID CSteamID [50]

    internal int ResultsReturned; // m_nResultsReturned int32
    internal int TotalResultCount; // m_nTotalResultCount int32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(FriendsEnumerateFollowingList_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.FriendsEnumerateFollowingList; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SetPersonaNameResponse_t : ICallbackData {
    [MarshalAs(UnmanagedType.I1)]
    internal bool Success; // m_bSuccess bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool LocalSuccess; // m_bLocalSuccess bool

    internal Result Result; // m_result EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SetPersonaNameResponse_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SetPersonaNameResponse; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct UnreadChatMessagesChanged_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(UnreadChatMessagesChanged_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.UnreadChatMessagesChanged; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct OverlayBrowserProtocolNavigation_t : ICallbackData {
    internal string RgchURIUTF8() {
        return Encoding.UTF8.GetString(RgchURI, 0, Array.IndexOf<byte>(RgchURI, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)] // byte[] rgchURI
    internal byte[] RgchURI; // rgchURI char [1024]

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(OverlayBrowserProtocolNavigation_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.OverlayBrowserProtocolNavigation; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct IPCountry_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(IPCountry_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.IPCountry; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LowBatteryPower_t : ICallbackData {
    internal byte MinutesBatteryLeft; // m_nMinutesBatteryLeft uint8

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LowBatteryPower_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LowBatteryPower; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamAPICallCompleted_t : ICallbackData {
    internal ulong AsyncCall; // m_hAsyncCall SteamAPICall_t
    internal int Callback; // m_iCallback int
    internal uint ParamCount; // m_cubParam uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamAPICallCompleted_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamAPICallCompleted; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamShutdown_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamShutdown_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamShutdown; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct CheckFileSignature_t : ICallbackData {
    internal CheckFileSignature CheckFileSignature; // m_eCheckFileSignature ECheckFileSignature

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(CheckFileSignature_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.CheckFileSignature; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GamepadTextInputDismissed_t : ICallbackData {
    [MarshalAs(UnmanagedType.I1)]
    internal bool Submitted; // m_bSubmitted bool

    internal uint SubmittedText; // m_unSubmittedText uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GamepadTextInputDismissed_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GamepadTextInputDismissed; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct FavoritesListChanged_t : ICallbackData {
    internal uint IP; // m_nIP uint32
    internal uint QueryPort; // m_nQueryPort uint32
    internal uint ConnPort; // m_nConnPort uint32
    internal uint AppID; // m_nAppID uint32
    internal uint Flags; // m_nFlags uint32

    [MarshalAs(UnmanagedType.I1)]
    internal bool Add; // m_bAdd bool

    internal uint AccountId; // m_unAccountId AccountID_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(FavoritesListChanged_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.FavoritesListChanged; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyInvite_t : ICallbackData {
    internal ulong SteamIDUser; // m_ulSteamIDUser uint64
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64
    internal ulong GameID; // m_ulGameID uint64

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyInvite_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LobbyInvite; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyEnter_t : ICallbackData {
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64
    internal uint GfChatPermissions; // m_rgfChatPermissions uint32

    [MarshalAs(UnmanagedType.I1)]
    internal bool Locked; // m_bLocked bool

    internal uint EChatRoomEnterResponse; // m_EChatRoomEnterResponse uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyEnter_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LobbyEnter; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyDataUpdate_t : ICallbackData {
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64
    internal ulong SteamIDMember; // m_ulSteamIDMember uint64
    internal byte Success; // m_bSuccess uint8

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyDataUpdate_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LobbyDataUpdate; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyChatUpdate_t : ICallbackData {
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64
    internal ulong SteamIDUserChanged; // m_ulSteamIDUserChanged uint64
    internal ulong SteamIDMakingChange; // m_ulSteamIDMakingChange uint64
    internal uint GfChatMemberStateChange; // m_rgfChatMemberStateChange uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyChatUpdate_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LobbyChatUpdate; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyChatMsg_t : ICallbackData {
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64
    internal ulong SteamIDUser; // m_ulSteamIDUser uint64
    internal byte ChatEntryType; // m_eChatEntryType uint8
    internal uint ChatID; // m_iChatID uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyChatMsg_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LobbyChatMsg; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyGameCreated_t : ICallbackData {
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64
    internal ulong SteamIDGameServer; // m_ulSteamIDGameServer uint64
    internal uint IP; // m_unIP uint32
    internal ushort Port; // m_usPort uint16

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyGameCreated_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LobbyGameCreated; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyMatchList_t : ICallbackData {
    internal uint LobbiesMatching; // m_nLobbiesMatching uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyMatchList_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LobbyMatchList; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyKicked_t : ICallbackData {
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64
    internal ulong SteamIDAdmin; // m_ulSteamIDAdmin uint64
    internal byte KickedDueToDisconnect; // m_bKickedDueToDisconnect uint8

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyKicked_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LobbyKicked; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyCreated_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyCreated_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LobbyCreated; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct PSNGameBootInviteResult_t : ICallbackData {
    [MarshalAs(UnmanagedType.I1)]
    internal bool GameBootInviteExists; // m_bGameBootInviteExists bool

    internal ulong SteamIDLobby; // m_steamIDLobby CSteamID

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(PSNGameBootInviteResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.PSNGameBootInviteResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct FavoritesListAccountsUpdated_t : ICallbackData {
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(FavoritesListAccountsUpdated_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.FavoritesListAccountsUpdated; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct SearchForGameProgressCallback_t : ICallbackData {
    internal ulong LSearchID; // m_ullSearchID uint64
    internal Result Result; // m_eResult EResult
    internal ulong LobbyID; // m_lobbyID CSteamID
    internal ulong SteamIDEndedSearch; // m_steamIDEndedSearch CSteamID
    internal int SecondsRemainingEstimate; // m_nSecondsRemainingEstimate int32
    internal int CPlayersSearching; // m_cPlayersSearching int32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SearchForGameProgressCallback_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SearchForGameProgressCallback; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct SearchForGameResultCallback_t : ICallbackData {
    internal ulong LSearchID; // m_ullSearchID uint64
    internal Result Result; // m_eResult EResult
    internal int CountPlayersInGame; // m_nCountPlayersInGame int32
    internal int CountAcceptedGame; // m_nCountAcceptedGame int32
    internal ulong SteamIDHost; // m_steamIDHost CSteamID

    [MarshalAs(UnmanagedType.I1)]
    internal bool FinalCallback; // m_bFinalCallback bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SearchForGameResultCallback_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SearchForGameResultCallback; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RequestPlayersForGameProgressCallback_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong LSearchID; // m_ullSearchID uint64

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RequestPlayersForGameProgressCallback_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RequestPlayersForGameProgressCallback; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct RequestPlayersForGameResultCallback_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong LSearchID; // m_ullSearchID uint64
    internal ulong SteamIDPlayerFound; // m_SteamIDPlayerFound CSteamID
    internal ulong SteamIDLobby; // m_SteamIDLobby CSteamID
    internal PlayerAcceptState_t PlayerAcceptState; // m_ePlayerAcceptState RequestPlayersForGameResultCallback_t::PlayerAcceptState_t
    internal int PlayerIndex; // m_nPlayerIndex int32
    internal int TotalPlayersFound; // m_nTotalPlayersFound int32
    internal int TotalPlayersAcceptedGame; // m_nTotalPlayersAcceptedGame int32
    internal int SuggestedTeamIndex; // m_nSuggestedTeamIndex int32
    internal ulong LUniqueGameID; // m_ullUniqueGameID uint64

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RequestPlayersForGameResultCallback_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RequestPlayersForGameResultCallback; }
    }

    #endregion

    internal enum PlayerAcceptState_t {
        Unknown = 0,
        PlayerAccepted = 1,
        PlayerDeclined = 2,
    }
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RequestPlayersForGameFinalResultCallback_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong LSearchID; // m_ullSearchID uint64
    internal ulong LUniqueGameID; // m_ullUniqueGameID uint64

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RequestPlayersForGameFinalResultCallback_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RequestPlayersForGameFinalResultCallback; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct SubmitPlayerResultResultCallback_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong UllUniqueGameID; // ullUniqueGameID uint64
    internal ulong SteamIDPlayer; // steamIDPlayer CSteamID

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SubmitPlayerResultResultCallback_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SubmitPlayerResultResultCallback; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct EndGameResultCallback_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong UllUniqueGameID; // ullUniqueGameID uint64

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(EndGameResultCallback_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.EndGameResultCallback; }
    }

    #endregion
}

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

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.JoinPartyCallback; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct CreateBeaconCallback_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong BeaconID; // m_ulBeaconID PartyBeaconID_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(CreateBeaconCallback_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.CreateBeaconCallback; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct ReservationNotificationCallback_t : ICallbackData {
    internal ulong BeaconID; // m_ulBeaconID PartyBeaconID_t
    internal ulong SteamIDJoiner; // m_steamIDJoiner CSteamID

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ReservationNotificationCallback_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.ReservationNotificationCallback; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct ChangeNumOpenSlotsCallback_t : ICallbackData {
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ChangeNumOpenSlotsCallback_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.ChangeNumOpenSlotsCallback; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct AvailableBeaconLocationsUpdated_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(AvailableBeaconLocationsUpdated_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.AvailableBeaconLocationsUpdated; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct ActiveBeaconsUpdated_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ActiveBeaconsUpdated_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.ActiveBeaconsUpdated; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageAppSyncedClient_t : ICallbackData {
    internal AppId AppID; // m_nAppID AppId_t
    internal Result Result; // m_eResult EResult
    internal int NumDownloads; // m_unNumDownloads int

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageAppSyncedClient_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageAppSyncedClient; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageAppSyncedServer_t : ICallbackData {
    internal AppId AppID; // m_nAppID AppId_t
    internal Result Result; // m_eResult EResult
    internal int NumUploads; // m_unNumUploads int

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageAppSyncedServer_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageAppSyncedServer; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageAppSyncProgress_t : ICallbackData {
    internal string CurrentFileUTF8() {
        return Encoding.UTF8.GetString(CurrentFile, 0, Array.IndexOf<byte>(CurrentFile, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)] // byte[] m_rgchCurrentFile
    internal byte[] CurrentFile; // m_rgchCurrentFile char [260]

    internal AppId AppID; // m_nAppID AppId_t
    internal uint BytesTransferredThisChunk; // m_uBytesTransferredThisChunk uint32
    internal double DAppPercentComplete; // m_dAppPercentComplete double

    [MarshalAs(UnmanagedType.I1)]
    internal bool Uploading; // m_bUploading bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageAppSyncProgress_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageAppSyncProgress; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageAppSyncStatusCheck_t : ICallbackData {
    internal AppId AppID; // m_nAppID AppId_t
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageAppSyncStatusCheck_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageAppSyncStatusCheck; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageFileShareResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong File; // m_hFile UGCHandle_t

    internal string FilenameUTF8() {
        return Encoding.UTF8.GetString(Filename, 0, Array.IndexOf<byte>(Filename, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)] // byte[] m_rgchFilename
    internal byte[] Filename; // m_rgchFilename char [260]

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageFileShareResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageFileShareResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStoragePublishFileResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

    [MarshalAs(UnmanagedType.I1)]
    internal bool UserNeedsToAcceptWorkshopLegalAgreement; // m_bUserNeedsToAcceptWorkshopLegalAgreement bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishFileResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStoragePublishFileResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageDeletePublishedFileResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageDeletePublishedFileResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageDeletePublishedFileResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageEnumerateUserPublishedFilesResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal int ResultsReturned; // m_nResultsReturned int32
    internal int TotalResultCount; // m_nTotalResultCount int32

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
    internal PublishedFileId[] GPublishedFileId; // m_rgPublishedFileId PublishedFileId_t [50]

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageEnumerateUserPublishedFilesResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageEnumerateUserPublishedFilesResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageSubscribePublishedFileResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageSubscribePublishedFileResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageSubscribePublishedFileResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageEnumerateUserSubscribedFilesResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal int ResultsReturned; // m_nResultsReturned int32
    internal int TotalResultCount; // m_nTotalResultCount int32

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
    internal PublishedFileId[] GPublishedFileId; // m_rgPublishedFileId PublishedFileId_t [50]

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U4)]
    internal uint[] GRTimeSubscribed; // m_rgRTimeSubscribed uint32 [50]

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageEnumerateUserSubscribedFilesResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageEnumerateUserSubscribedFilesResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageUnsubscribePublishedFileResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageUnsubscribePublishedFileResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageUnsubscribePublishedFileResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageUpdatePublishedFileResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

    [MarshalAs(UnmanagedType.I1)]
    internal bool UserNeedsToAcceptWorkshopLegalAgreement; // m_bUserNeedsToAcceptWorkshopLegalAgreement bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageUpdatePublishedFileResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageUpdatePublishedFileResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageDownloadUGCResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong File; // m_hFile UGCHandle_t
    internal AppId AppID; // m_nAppID AppId_t
    internal int SizeInBytes; // m_nSizeInBytes int32

    internal string PchFileNameUTF8() {
        return Encoding.UTF8.GetString(PchFileName, 0, Array.IndexOf<byte>(PchFileName, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)] // byte[] m_pchFileName
    internal byte[] PchFileName; // m_pchFileName char [260]

    internal ulong SteamIDOwner; // m_ulSteamIDOwner uint64

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageDownloadUGCResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageDownloadUGCResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageGetPublishedFileDetailsResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal AppId CreatorAppID; // m_nCreatorAppID AppId_t
    internal AppId ConsumerAppID; // m_nConsumerAppID AppId_t

    internal string TitleUTF8() {
        return Encoding.UTF8.GetString(Title, 0, Array.IndexOf<byte>(Title, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)] // byte[] m_rgchTitle
    internal byte[] Title; // m_rgchTitle char [129]

    internal string DescriptionUTF8() {
        return Encoding.UTF8.GetString(Description, 0, Array.IndexOf<byte>(Description, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8000)] // byte[] m_rgchDescription
    internal byte[] Description; // m_rgchDescription char [8000]

    internal ulong File; // m_hFile UGCHandle_t
    internal ulong PreviewFile; // m_hPreviewFile UGCHandle_t
    internal ulong SteamIDOwner; // m_ulSteamIDOwner uint64
    internal uint TimeCreated; // m_rtimeCreated uint32
    internal uint TimeUpdated; // m_rtimeUpdated uint32
    internal RemoteStoragePublishedFileVisibility Visibility; // m_eVisibility ERemoteStoragePublishedFileVisibility

    [MarshalAs(UnmanagedType.I1)]
    internal bool Banned; // m_bBanned bool

    internal string TagsUTF8() {
        return Encoding.UTF8.GetString(Tags, 0, Array.IndexOf<byte>(Tags, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1025)] // byte[] m_rgchTags
    internal byte[] Tags; // m_rgchTags char [1025]

    [MarshalAs(UnmanagedType.I1)]
    internal bool TagsTruncated; // m_bTagsTruncated bool

    internal string PchFileNameUTF8() {
        return Encoding.UTF8.GetString(PchFileName, 0, Array.IndexOf<byte>(PchFileName, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)] // byte[] m_pchFileName
    internal byte[] PchFileName; // m_pchFileName char [260]

    internal int FileSize; // m_nFileSize int32
    internal int PreviewFileSize; // m_nPreviewFileSize int32

    internal string URLUTF8() {
        return Encoding.UTF8.GetString(URL, 0, Array.IndexOf<byte>(URL, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] // byte[] m_rgchURL
    internal byte[] URL; // m_rgchURL char [256]

    internal WorkshopFileType FileType; // m_eFileType EWorkshopFileType

    [MarshalAs(UnmanagedType.I1)]
    internal bool AcceptedForUse; // m_bAcceptedForUse bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageGetPublishedFileDetailsResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageGetPublishedFileDetailsResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageEnumerateWorkshopFilesResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal int ResultsReturned; // m_nResultsReturned int32
    internal int TotalResultCount; // m_nTotalResultCount int32

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
    internal PublishedFileId[] GPublishedFileId; // m_rgPublishedFileId PublishedFileId_t [50]

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.R4)]
    internal float[] GScore; // m_rgScore float [50]

    internal AppId AppId; // m_nAppId AppId_t
    internal uint StartIndex; // m_unStartIndex uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageEnumerateWorkshopFilesResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageEnumerateWorkshopFilesResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageGetPublishedItemVoteDetailsResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_unPublishedFileId PublishedFileId_t
    internal int VotesFor; // m_nVotesFor int32
    internal int VotesAgainst; // m_nVotesAgainst int32
    internal int Reports; // m_nReports int32
    internal float FScore; // m_fScore float

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageGetPublishedItemVoteDetailsResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageGetPublishedItemVoteDetailsResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStoragePublishedFileSubscribed_t : ICallbackData {
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal AppId AppID; // m_nAppID AppId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishedFileSubscribed_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStoragePublishedFileSubscribed; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStoragePublishedFileUnsubscribed_t : ICallbackData {
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal AppId AppID; // m_nAppID AppId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishedFileUnsubscribed_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStoragePublishedFileUnsubscribed; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStoragePublishedFileDeleted_t : ICallbackData {
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal AppId AppID; // m_nAppID AppId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishedFileDeleted_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStoragePublishedFileDeleted; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageUpdateUserPublishedItemVoteResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageUpdateUserPublishedItemVoteResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageUpdateUserPublishedItemVoteResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageUserVoteDetails_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal WorkshopVote Vote; // m_eVote EWorkshopVote

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageUserVoteDetails_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageUserVoteDetails; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageEnumerateUserSharedWorkshopFilesResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal int ResultsReturned; // m_nResultsReturned int32
    internal int TotalResultCount; // m_nTotalResultCount int32

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
    internal PublishedFileId[] GPublishedFileId; // m_rgPublishedFileId PublishedFileId_t [50]

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageEnumerateUserSharedWorkshopFilesResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageEnumerateUserSharedWorkshopFilesResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageSetUserPublishedFileActionResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal WorkshopFileAction Action; // m_eAction EWorkshopFileAction

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageSetUserPublishedFileActionResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageSetUserPublishedFileActionResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageEnumeratePublishedFilesByUserActionResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal WorkshopFileAction Action; // m_eAction EWorkshopFileAction
    internal int ResultsReturned; // m_nResultsReturned int32
    internal int TotalResultCount; // m_nTotalResultCount int32

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
    internal PublishedFileId[] GPublishedFileId; // m_rgPublishedFileId PublishedFileId_t [50]

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U4)]
    internal uint[] GRTimeUpdated; // m_rgRTimeUpdated uint32 [50]

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageEnumeratePublishedFilesByUserActionResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageEnumeratePublishedFilesByUserActionResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStoragePublishFileProgress_t : ICallbackData {
    internal double DPercentFile; // m_dPercentFile double

    [MarshalAs(UnmanagedType.I1)]
    internal bool Preview; // m_bPreview bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishFileProgress_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStoragePublishFileProgress; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStoragePublishedFileUpdated_t : ICallbackData {
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal AppId AppID; // m_nAppID AppId_t
    internal ulong Unused; // m_ulUnused uint64

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishedFileUpdated_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStoragePublishedFileUpdated; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageFileWriteAsyncComplete_t : ICallbackData {
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageFileWriteAsyncComplete_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageFileWriteAsyncComplete; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageFileReadAsyncComplete_t : ICallbackData {
    internal ulong FileReadAsync; // m_hFileReadAsync SteamAPICall_t
    internal Result Result; // m_eResult EResult
    internal uint Offset; // m_nOffset uint32
    internal uint Read; // m_cubRead uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageFileReadAsyncComplete_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoteStorageFileReadAsyncComplete; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct UserStatsReceived_t : ICallbackData {
    internal ulong GameID; // m_nGameID uint64
    internal Result Result; // m_eResult EResult
    internal ulong SteamIDUser; // m_steamIDUser CSteamID

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(UserStatsReceived_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.UserStatsReceived; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct UserStatsStored_t : ICallbackData {
    internal ulong GameID; // m_nGameID uint64
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(UserStatsStored_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.UserStatsStored; }
    }

    #endregion
}

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

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.UserAchievementStored; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LeaderboardFindResult_t : ICallbackData {
    internal ulong SteamLeaderboard; // m_hSteamLeaderboard SteamLeaderboard_t
    internal byte LeaderboardFound; // m_bLeaderboardFound uint8

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LeaderboardFindResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LeaderboardFindResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LeaderboardScoresDownloaded_t : ICallbackData {
    internal ulong SteamLeaderboard; // m_hSteamLeaderboard SteamLeaderboard_t
    internal ulong SteamLeaderboardEntries; // m_hSteamLeaderboardEntries SteamLeaderboardEntries_t
    internal int CEntryCount; // m_cEntryCount int

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LeaderboardScoresDownloaded_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LeaderboardScoresDownloaded; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LeaderboardScoreUploaded_t : ICallbackData {
    internal byte Success; // m_bSuccess uint8
    internal ulong SteamLeaderboard; // m_hSteamLeaderboard SteamLeaderboard_t
    internal int Score; // m_nScore int32
    internal byte ScoreChanged; // m_bScoreChanged uint8
    internal int GlobalRankNew; // m_nGlobalRankNew int
    internal int GlobalRankPrevious; // m_nGlobalRankPrevious int

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LeaderboardScoreUploaded_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LeaderboardScoreUploaded; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct NumberOfCurrentPlayers_t : ICallbackData {
    internal byte Success; // m_bSuccess uint8
    internal int CPlayers; // m_cPlayers int32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(NumberOfCurrentPlayers_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.NumberOfCurrentPlayers; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct UserStatsUnloaded_t : ICallbackData {
    internal ulong SteamIDUser; // m_steamIDUser CSteamID

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(UserStatsUnloaded_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.UserStatsUnloaded; }
    }

    #endregion
}

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

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.UserAchievementIconFetched; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GlobalAchievementPercentagesReady_t : ICallbackData {
    internal ulong GameID; // m_nGameID uint64
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GlobalAchievementPercentagesReady_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GlobalAchievementPercentagesReady; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LeaderboardUGCSet_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong SteamLeaderboard; // m_hSteamLeaderboard SteamLeaderboard_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LeaderboardUGCSet_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.LeaderboardUGCSet; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GlobalStatsReceived_t : ICallbackData {
    internal ulong GameID; // m_nGameID uint64
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GlobalStatsReceived_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GlobalStatsReceived; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct DlcInstalled_t : ICallbackData {
    internal AppId AppID; // m_nAppID AppId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(DlcInstalled_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.DlcInstalled; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RegisterActivationCodeResponse_t : ICallbackData {
    internal RegisterActivationCodeResult Result; // m_eResult ERegisterActivationCodeResult
    internal uint PackageRegistered; // m_unPackageRegistered uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RegisterActivationCodeResponse_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RegisterActivationCodeResponse; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct NewUrlLaunchParameters_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(NewUrlLaunchParameters_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.NewUrlLaunchParameters; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct AppProofOfPurchaseKeyResponse_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal uint AppID; // m_nAppID uint32
    internal uint CchKeyLength; // m_cchKeyLength uint32

    internal string KeyUTF8() {
        return Encoding.UTF8.GetString(Key, 0, Array.IndexOf<byte>(Key, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 240)] // byte[] m_rgchKey
    internal byte[] Key; // m_rgchKey char [240]

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(AppProofOfPurchaseKeyResponse_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.AppProofOfPurchaseKeyResponse; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct FileDetailsResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong FileSize; // m_ulFileSize uint64

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)] //  m_FileSHA
    internal byte[] FileSHA; // m_FileSHA uint8 [20]

    internal uint Flags; // m_unFlags uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(FileDetailsResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.FileDetailsResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct TimedTrialStatus_t : ICallbackData {
    internal AppId AppID; // m_unAppID AppId_t

    [MarshalAs(UnmanagedType.I1)]
    internal bool IsOffline; // m_bIsOffline bool

    internal uint SecondsAllowed; // m_unSecondsAllowed uint32
    internal uint SecondsPlayed; // m_unSecondsPlayed uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(TimedTrialStatus_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.TimedTrialStatus; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct P2PSessionRequest_t : ICallbackData {
    internal ulong SteamIDRemote; // m_steamIDRemote CSteamID

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(P2PSessionRequest_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.P2PSessionRequest; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct P2PSessionConnectFail_t : ICallbackData {
    internal ulong SteamIDRemote; // m_steamIDRemote CSteamID
    internal byte P2PSessionError; // m_eP2PSessionError uint8

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(P2PSessionConnectFail_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.P2PSessionConnectFail; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct ScreenshotReady_t : ICallbackData {
    internal uint Local; // m_hLocal ScreenshotHandle
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ScreenshotReady_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.ScreenshotReady; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct ScreenshotRequested_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ScreenshotRequested_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.ScreenshotRequested; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct PlaybackStatusHasChanged_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(PlaybackStatusHasChanged_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.PlaybackStatusHasChanged; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct VolumeHasChanged_t : ICallbackData {
    internal float NewVolume; // m_flNewVolume float

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(VolumeHasChanged_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.VolumeHasChanged; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerRemoteWillActivate_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerRemoteWillActivate_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MusicPlayerRemoteWillActivate; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerRemoteWillDeactivate_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerRemoteWillDeactivate_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MusicPlayerRemoteWillDeactivate; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerRemoteToFront_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerRemoteToFront_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MusicPlayerRemoteToFront; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWillQuit_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWillQuit_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MusicPlayerWillQuit; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWantsPlay_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsPlay_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MusicPlayerWantsPlay; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWantsPause_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsPause_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MusicPlayerWantsPause; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWantsPlayPrevious_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsPlayPrevious_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MusicPlayerWantsPlayPrevious; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWantsPlayNext_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsPlayNext_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MusicPlayerWantsPlayNext; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWantsShuffled_t : ICallbackData {
    [MarshalAs(UnmanagedType.I1)]
    internal bool Shuffled; // m_bShuffled bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsShuffled_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MusicPlayerWantsShuffled; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWantsLooped_t : ICallbackData {
    [MarshalAs(UnmanagedType.I1)]
    internal bool Looped; // m_bLooped bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsLooped_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MusicPlayerWantsLooped; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWantsVolume_t : ICallbackData {
    internal float NewVolume; // m_flNewVolume float

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsVolume_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MusicPlayerWantsVolume; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerSelectsQueueEntry_t : ICallbackData {
    internal int NID; // nID int

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerSelectsQueueEntry_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MusicPlayerSelectsQueueEntry; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerSelectsPlaylistEntry_t : ICallbackData {
    internal int NID; // nID int

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerSelectsPlaylistEntry_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MusicPlayerSelectsPlaylistEntry; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWantsPlayingRepeatStatus_t : ICallbackData {
    internal int PlayingRepeatStatus; // m_nPlayingRepeatStatus int

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsPlayingRepeatStatus_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.MusicPlayerWantsPlayingRepeatStatus; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTTPRequestCompleted_t : ICallbackData {
    internal uint Request; // m_hRequest HTTPRequestHandle
    internal ulong ContextValue; // m_ulContextValue uint64

    [MarshalAs(UnmanagedType.I1)]
    internal bool RequestSuccessful; // m_bRequestSuccessful bool

    internal HTTPStatusCode StatusCode; // m_eStatusCode EHTTPStatusCode
    internal uint BodySize; // m_unBodySize uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTTPRequestCompleted_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTTPRequestCompleted; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTTPRequestHeadersReceived_t : ICallbackData {
    internal uint Request; // m_hRequest HTTPRequestHandle
    internal ulong ContextValue; // m_ulContextValue uint64

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTTPRequestHeadersReceived_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTTPRequestHeadersReceived; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTTPRequestDataReceived_t : ICallbackData {
    internal uint Request; // m_hRequest HTTPRequestHandle
    internal ulong ContextValue; // m_ulContextValue uint64
    internal uint COffset; // m_cOffset uint32
    internal uint CBytesReceived; // m_cBytesReceived uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTTPRequestDataReceived_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTTPRequestDataReceived; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamUGCQueryCompleted_t : ICallbackData {
    internal ulong Handle; // m_handle UGCQueryHandle_t
    internal Result Result; // m_eResult EResult
    internal uint NumResultsReturned; // m_unNumResultsReturned uint32
    internal uint TotalMatchingResults; // m_unTotalMatchingResults uint32

    [MarshalAs(UnmanagedType.I1)]
    internal bool CachedData; // m_bCachedData bool

    internal string NextCursorUTF8() {
        return Encoding.UTF8.GetString(NextCursor, 0, Array.IndexOf<byte>(NextCursor, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] // byte[] m_rgchNextCursor
    internal byte[] NextCursor; // m_rgchNextCursor char [256]

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamUGCQueryCompleted_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamUGCQueryCompleted; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamUGCRequestUGCDetailsResult_t : ICallbackData {
    internal SteamUGCDetails_t Details; // m_details SteamUGCDetails_t

    [MarshalAs(UnmanagedType.I1)]
    internal bool CachedData; // m_bCachedData bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamUGCRequestUGCDetailsResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamUGCRequestUGCDetailsResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct CreateItemResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

    [MarshalAs(UnmanagedType.I1)]
    internal bool UserNeedsToAcceptWorkshopLegalAgreement; // m_bUserNeedsToAcceptWorkshopLegalAgreement bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(CreateItemResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.CreateItemResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SubmitItemUpdateResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult

    [MarshalAs(UnmanagedType.I1)]
    internal bool UserNeedsToAcceptWorkshopLegalAgreement; // m_bUserNeedsToAcceptWorkshopLegalAgreement bool

    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SubmitItemUpdateResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SubmitItemUpdateResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct ItemInstalled_t : ICallbackData {
    internal AppId AppID; // m_unAppID AppId_t
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ItemInstalled_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.ItemInstalled; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct DownloadItemResult_t : ICallbackData {
    internal AppId AppID; // m_unAppID AppId_t
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(DownloadItemResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.DownloadItemResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct UserFavoriteItemsListChanged_t : ICallbackData {
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal Result Result; // m_eResult EResult

    [MarshalAs(UnmanagedType.I1)]
    internal bool WasAddRequest; // m_bWasAddRequest bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(UserFavoriteItemsListChanged_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.UserFavoriteItemsListChanged; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SetUserItemVoteResult_t : ICallbackData {
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal Result Result; // m_eResult EResult

    [MarshalAs(UnmanagedType.I1)]
    internal bool VoteUp; // m_bVoteUp bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SetUserItemVoteResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SetUserItemVoteResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GetUserItemVoteResult_t : ICallbackData {
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal Result Result; // m_eResult EResult

    [MarshalAs(UnmanagedType.I1)]
    internal bool VotedUp; // m_bVotedUp bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool VotedDown; // m_bVotedDown bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool VoteSkipped; // m_bVoteSkipped bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GetUserItemVoteResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GetUserItemVoteResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct StartPlaytimeTrackingResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(StartPlaytimeTrackingResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.StartPlaytimeTrackingResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct StopPlaytimeTrackingResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(StopPlaytimeTrackingResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.StopPlaytimeTrackingResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct AddUGCDependencyResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal PublishedFileId ChildPublishedFileId; // m_nChildPublishedFileId PublishedFileId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(AddUGCDependencyResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.AddUGCDependencyResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoveUGCDependencyResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal PublishedFileId ChildPublishedFileId; // m_nChildPublishedFileId PublishedFileId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoveUGCDependencyResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoveUGCDependencyResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct AddAppDependencyResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal AppId AppID; // m_nAppID AppId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(AddAppDependencyResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.AddAppDependencyResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoveAppDependencyResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal AppId AppID; // m_nAppID AppId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoveAppDependencyResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.RemoveAppDependencyResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GetAppDependenciesResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.U4)]
    internal AppId[] GAppIDs; // m_rgAppIDs AppId_t [32]

    internal uint NumAppDependencies; // m_nNumAppDependencies uint32
    internal uint TotalNumAppDependencies; // m_nTotalNumAppDependencies uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GetAppDependenciesResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GetAppDependenciesResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct DeleteItemResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(DeleteItemResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.DeleteItemResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamAppInstalled_t : ICallbackData {
    internal AppId AppID; // m_nAppID AppId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamAppInstalled_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamAppInstalled; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamAppUninstalled_t : ICallbackData {
    internal AppId AppID; // m_nAppID AppId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamAppUninstalled_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamAppUninstalled; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_BrowserReady_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_BrowserReady_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_BrowserReady; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_NeedsPaint_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PBGRA; // pBGRA const char *
    internal uint UnWide; // unWide uint32
    internal uint UnTall; // unTall uint32
    internal uint UnUpdateX; // unUpdateX uint32
    internal uint UnUpdateY; // unUpdateY uint32
    internal uint UnUpdateWide; // unUpdateWide uint32
    internal uint UnUpdateTall; // unUpdateTall uint32
    internal uint UnScrollX; // unScrollX uint32
    internal uint UnScrollY; // unScrollY uint32
    internal float FlPageScale; // flPageScale float
    internal uint UnPageSerial; // unPageSerial uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_NeedsPaint_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_NeedsPaint; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_StartRequest_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchURL; // pchURL const char *
    internal string PchTarget; // pchTarget const char *
    internal string PchPostData; // pchPostData const char *

    [MarshalAs(UnmanagedType.I1)]
    internal bool BIsRedirect; // bIsRedirect bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_StartRequest_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_StartRequest; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_CloseBrowser_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_CloseBrowser_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_CloseBrowser; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_URLChanged_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchURL; // pchURL const char *
    internal string PchPostData; // pchPostData const char *

    [MarshalAs(UnmanagedType.I1)]
    internal bool BIsRedirect; // bIsRedirect bool

    internal string PchPageTitle; // pchPageTitle const char *

    [MarshalAs(UnmanagedType.I1)]
    internal bool BNewNavigation; // bNewNavigation bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_URLChanged_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_URLChanged; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_FinishedRequest_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchURL; // pchURL const char *
    internal string PchPageTitle; // pchPageTitle const char *

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_FinishedRequest_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_FinishedRequest; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_OpenLinkInNewTab_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchURL; // pchURL const char *

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_OpenLinkInNewTab_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_OpenLinkInNewTab; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_ChangedTitle_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchTitle; // pchTitle const char *

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_ChangedTitle_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_ChangedTitle; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_SearchResults_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal uint UnResults; // unResults uint32
    internal uint UnCurrentMatch; // unCurrentMatch uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_SearchResults_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_SearchResults; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_CanGoBackAndForward_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser

    [MarshalAs(UnmanagedType.I1)]
    internal bool BCanGoBack; // bCanGoBack bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool BCanGoForward; // bCanGoForward bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_CanGoBackAndForward_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_CanGoBackAndForward; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_HorizontalScroll_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal uint UnScrollMax; // unScrollMax uint32
    internal uint UnScrollCurrent; // unScrollCurrent uint32
    internal float FlPageScale; // flPageScale float

    [MarshalAs(UnmanagedType.I1)]
    internal bool BVisible; // bVisible bool

    internal uint UnPageSize; // unPageSize uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_HorizontalScroll_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_HorizontalScroll; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_VerticalScroll_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal uint UnScrollMax; // unScrollMax uint32
    internal uint UnScrollCurrent; // unScrollCurrent uint32
    internal float FlPageScale; // flPageScale float

    [MarshalAs(UnmanagedType.I1)]
    internal bool BVisible; // bVisible bool

    internal uint UnPageSize; // unPageSize uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_VerticalScroll_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_VerticalScroll; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_LinkAtPosition_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal uint X; // x uint32
    internal uint Y; // y uint32
    internal string PchURL; // pchURL const char *

    [MarshalAs(UnmanagedType.I1)]
    internal bool BInput; // bInput bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool BLiveLink; // bLiveLink bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_LinkAtPosition_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_LinkAtPosition; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_JSAlert_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchMessage; // pchMessage const char *

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_JSAlert_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_JSAlert; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_JSConfirm_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchMessage; // pchMessage const char *

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_JSConfirm_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_JSConfirm; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_FileOpenDialog_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchTitle; // pchTitle const char *
    internal string PchInitialFile; // pchInitialFile const char *

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_FileOpenDialog_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_FileOpenDialog; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_NewWindow_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchURL; // pchURL const char *
    internal uint UnX; // unX uint32
    internal uint UnY; // unY uint32
    internal uint UnWide; // unWide uint32
    internal uint UnTall; // unTall uint32
    internal uint UnNewWindow_BrowserHandle_IGNORE; // unNewWindow_BrowserHandle_IGNORE HHTMLBrowser

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_NewWindow_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_NewWindow; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_SetCursor_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal uint EMouseCursor; // eMouseCursor uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_SetCursor_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_SetCursor; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_StatusText_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchMsg; // pchMsg const char *

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_StatusText_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_StatusText; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_ShowToolTip_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchMsg; // pchMsg const char *

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_ShowToolTip_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_ShowToolTip; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_UpdateToolTip_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchMsg; // pchMsg const char *

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_UpdateToolTip_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_UpdateToolTip; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_HideToolTip_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_HideToolTip_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_HideToolTip; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_BrowserRestarted_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal uint UnOldBrowserHandle; // unOldBrowserHandle HHTMLBrowser

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_BrowserRestarted_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.HTML_BrowserRestarted; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamInventoryResultReady_t : ICallbackData {
    internal int Handle; // m_handle SteamInventoryResult_t
    internal Result Result; // m_result EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamInventoryResultReady_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamInventoryResultReady; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamInventoryFullUpdate_t : ICallbackData {
    internal int Handle; // m_handle SteamInventoryResult_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamInventoryFullUpdate_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamInventoryFullUpdate; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamInventoryDefinitionUpdate_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamInventoryDefinitionUpdate_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamInventoryDefinitionUpdate; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct SteamInventoryEligiblePromoItemDefIDs_t : ICallbackData {
    internal Result Result; // m_result EResult
    internal ulong SteamID; // m_steamID CSteamID
    internal int UmEligiblePromoItemDefs; // m_numEligiblePromoItemDefs int

    [MarshalAs(UnmanagedType.I1)]
    internal bool CachedData; // m_bCachedData bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamInventoryEligiblePromoItemDefIDs_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamInventoryEligiblePromoItemDefIDs; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamInventoryStartPurchaseResult_t : ICallbackData {
    internal Result Result; // m_result EResult
    internal ulong OrderID; // m_ulOrderID uint64
    internal ulong TransID; // m_ulTransID uint64

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamInventoryStartPurchaseResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamInventoryStartPurchaseResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamInventoryRequestPricesResult_t : ICallbackData {
    internal Result Result; // m_result EResult

    internal string CurrencyUTF8() {
        return Encoding.UTF8.GetString(Currency, 0, Array.IndexOf<byte>(Currency, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // byte[] m_rgchCurrency
    internal byte[] Currency; // m_rgchCurrency char [4]

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamInventoryRequestPricesResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamInventoryRequestPricesResult; }
    }

    #endregion
}

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

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GetVideoURLResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GetOPFSettingsResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal AppId VideoAppID; // m_unVideoAppID AppId_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GetOPFSettingsResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GetOPFSettingsResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamParentalSettingsChanged_t : ICallbackData {
    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamParentalSettingsChanged_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamParentalSettingsChanged; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamRemotePlaySessionConnected_t : ICallbackData {
    internal uint SessionID; // m_unSessionID RemotePlaySessionID_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamRemotePlaySessionConnected_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamRemotePlaySessionConnected; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamRemotePlaySessionDisconnected_t : ICallbackData {
    internal uint SessionID; // m_unSessionID RemotePlaySessionID_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamRemotePlaySessionDisconnected_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamRemotePlaySessionDisconnected; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamNetworkingMessagesSessionRequest_t : ICallbackData {
    internal NetIdentity DentityRemote; // m_identityRemote SteamNetworkingIdentity

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamNetworkingMessagesSessionRequest_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamNetworkingMessagesSessionRequest; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamNetworkingMessagesSessionFailed_t : ICallbackData {
    internal ConnectionInfo Nfo; // m_info SteamNetConnectionInfo_t

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamNetworkingMessagesSessionFailed_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamNetworkingMessagesSessionFailed; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamNetConnectionStatusChangedCallback_t : ICallbackData {
    internal Connection Conn; // m_hConn HSteamNetConnection
    internal ConnectionInfo Nfo; // m_info SteamNetConnectionInfo_t
    internal ConnectionState OldState; // m_eOldState ESteamNetworkingConnectionState

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamNetConnectionStatusChangedCallback_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamNetConnectionStatusChangedCallback; }
    }

    #endregion
}

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

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamNetAuthenticationStatus; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamRelayNetworkStatus_t : ICallbackData {
    internal SteamNetworkingAvailability Avail; // m_eAvail ESteamNetworkingAvailability
    internal int PingMeasurementInProgress; // m_bPingMeasurementInProgress int
    internal SteamNetworkingAvailability AvailNetworkConfig; // m_eAvailNetworkConfig ESteamNetworkingAvailability
    internal SteamNetworkingAvailability AvailAnyRelay; // m_eAvailAnyRelay ESteamNetworkingAvailability

    internal string DebugMsgUTF8() {
        return Encoding.UTF8.GetString(DebugMsg, 0, Array.IndexOf<byte>(DebugMsg, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] // byte[] m_debugMsg
    internal byte[] DebugMsg; // m_debugMsg char [256]

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamRelayNetworkStatus_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.SteamRelayNetworkStatus; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GSClientApprove_t : ICallbackData {
    internal ulong SteamID; // m_SteamID CSteamID
    internal ulong OwnerSteamID; // m_OwnerSteamID CSteamID

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSClientApprove_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GSClientApprove; }
    }

    #endregion
}

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

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GSClientDeny; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GSClientKick_t : ICallbackData {
    internal ulong SteamID; // m_SteamID CSteamID
    internal DenyReason DenyReason; // m_eDenyReason EDenyReason

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSClientKick_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GSClientKick; }
    }

    #endregion
}

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

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GSClientAchievementStatus; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GSPolicyResponse_t : ICallbackData {
    internal byte Secure; // m_bSecure uint8

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSPolicyResponse_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GSPolicyResponse; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GSGameplayStats_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal int Rank; // m_nRank int32
    internal uint TotalConnects; // m_unTotalConnects uint32
    internal uint TotalMinutesPlayed; // m_unTotalMinutesPlayed uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSGameplayStats_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GSGameplayStats; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GSClientGroupStatus_t : ICallbackData {
    internal ulong SteamIDUser; // m_SteamIDUser CSteamID
    internal ulong SteamIDGroup; // m_SteamIDGroup CSteamID

    [MarshalAs(UnmanagedType.I1)]
    internal bool Member; // m_bMember bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool Officer; // m_bOfficer bool

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSClientGroupStatus_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GSClientGroupStatus; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GSReputation_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal uint ReputationScore; // m_unReputationScore uint32

    [MarshalAs(UnmanagedType.I1)]
    internal bool Banned; // m_bBanned bool

    internal uint BannedIP; // m_unBannedIP uint32
    internal ushort BannedPort; // m_usBannedPort uint16
    internal ulong BannedGameID; // m_ulBannedGameID uint64
    internal uint BanExpires; // m_unBanExpires uint32

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSReputation_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GSReputation; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct AssociateWithClanResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(AssociateWithClanResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.AssociateWithClanResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct ComputeNewPlayerCompatibilityResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal int CPlayersThatDontLikeCandidate; // m_cPlayersThatDontLikeCandidate int
    internal int CPlayersThatCandidateDoesntLike; // m_cPlayersThatCandidateDoesntLike int
    internal int CClanPlayersThatDontLikeCandidate; // m_cClanPlayersThatDontLikeCandidate int
    internal ulong SteamIDCandidate; // m_SteamIDCandidate CSteamID

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ComputeNewPlayerCompatibilityResult_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.ComputeNewPlayerCompatibilityResult; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GSStatsReceived_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong SteamIDUser; // m_steamIDUser CSteamID

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSStatsReceived_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GSStatsReceived; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GSStatsStored_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong SteamIDUser; // m_steamIDUser CSteamID

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSStatsStored_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GSStatsStored; }
    }

    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GSStatsUnloaded_t : ICallbackData {
    internal ulong SteamIDUser; // m_steamIDUser CSteamID

    #region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GSStatsUnloaded_t));

    public int DataSize {
        get { return _datasize; }
    }

    public CallbackType CallbackType {
        get { return CallbackType.GSStatsUnloaded; }
    }

    #endregion
}
