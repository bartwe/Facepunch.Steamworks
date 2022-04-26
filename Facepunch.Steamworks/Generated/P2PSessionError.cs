namespace Steamworks;

public enum P2PSessionError {
    None = 0,
    NoRightsToApp = 2,
    Timeout = 4,
    NotRunningApp_DELETED = 1,
    DestinationNotLoggedIn_DELETED = 3,
    Max = 5,
}
