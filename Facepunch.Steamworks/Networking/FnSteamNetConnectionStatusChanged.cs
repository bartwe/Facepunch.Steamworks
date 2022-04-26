using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks;

[UnmanagedFunctionPointer(Platform.CC)]
delegate void FnSteamNetConnectionStatusChanged(ref SteamNetConnectionStatusChangedCallback_t arg);
