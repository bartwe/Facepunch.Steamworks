using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks;

[UnmanagedFunctionPointer(Platform.CC)]
delegate void FnSteamNetworkingMessagesSessionRequest(ref SteamNetworkingMessagesSessionRequest_t arg);
