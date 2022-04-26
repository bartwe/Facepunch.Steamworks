namespace Steamworks;

enum NetIdentityType {
    Invalid = 0,
    SteamID = 16,
    XboxPairwiseID = 17,
    SonyPSN = 18,
    GoogleStadia = 19,
    IPAddress = 1,
    GenericString = 2,
    GenericBytes = 3,
    UnknownType = 4,
    Force32bit = 2147483647,
}
