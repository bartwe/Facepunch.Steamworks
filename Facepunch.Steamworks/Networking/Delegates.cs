﻿using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks {
    [UnmanagedFunctionPointer(Platform.CC)]
    delegate void NetDebugFunc([In] NetDebugOutput nType, [In] IntPtr pszMsg);

    [UnmanagedFunctionPointer(Platform.CC)]
    delegate void FnSteamNetConnectionStatusChanged(ref SteamNetConnectionStatusChangedCallback_t arg);

    [UnmanagedFunctionPointer(Platform.CC)]
    delegate void FnSteamNetAuthenticationStatusChanged(ref SteamNetAuthenticationStatus_t arg);

    [UnmanagedFunctionPointer(Platform.CC)]
    delegate void FnSteamRelayNetworkStatusChanged(ref SteamRelayNetworkStatus_t arg);

    [UnmanagedFunctionPointer(Platform.CC)]
    delegate void FnSteamNetworkingMessagesSessionRequest(ref SteamNetworkingMessagesSessionRequest_t arg);

    [UnmanagedFunctionPointer(Platform.CC)]
    delegate void FnSteamNetworkingMessagesSessionFailed(ref SteamNetworkingMessagesSessionFailed_t arg);
}
