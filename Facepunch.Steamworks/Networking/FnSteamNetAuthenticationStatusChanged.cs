using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks;

[UnmanagedFunctionPointer(Platform.CC)]
delegate void FnSteamNetAuthenticationStatusChanged(ref SteamNetAuthenticationStatus_t arg);