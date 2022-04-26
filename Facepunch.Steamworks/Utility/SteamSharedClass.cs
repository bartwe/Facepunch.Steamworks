﻿namespace Steamworks;

public abstract class SteamSharedClass<T> : SteamClass {
    internal static SteamInterface InterfaceClient;
    internal static SteamInterface InterfaceServer;

    internal static SteamInterface Interface => InterfaceClient ?? InterfaceServer;

    internal override bool InitializeInterface(bool server) {
        return false;
    }

    internal virtual void SetInterface(bool server, SteamInterface iface) {
        if (server) {
            InterfaceServer = iface;
        }

        if (!server) {
            InterfaceClient = iface;
        }
    }

    internal override void DestroyInterface(bool server) {
        if (!server) {
            InterfaceClient = null;
        }

        if (server) {
            InterfaceServer = null;
        }
    }
}
