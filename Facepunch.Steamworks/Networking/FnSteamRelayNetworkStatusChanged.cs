using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks;

[UnmanagedFunctionPointer(Platform.CC)]
delegate void FnSteamRelayNetworkStatusChanged(ref SteamRelayNetworkStatus_t arg);
