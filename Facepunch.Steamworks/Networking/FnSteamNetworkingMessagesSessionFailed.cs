using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks;

[UnmanagedFunctionPointer(Platform.CC)]
delegate void FnSteamNetworkingMessagesSessionFailed(ref SteamNetworkingMessagesSessionFailed_t arg);
