namespace Steamworks;

enum RegisterActivationCodeResult {
    ResultOK = 0,
    ResultFail = 1,
    ResultAlreadyRegistered = 2,
    ResultTimeout = 3,
    AlreadyOwned = 4,
}