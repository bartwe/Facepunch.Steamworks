﻿using System;

namespace Steamworks;

public abstract class SteamServerClass<T> : SteamClass {
    internal static SteamInterface Interface;

    internal override bool InitializeInterface(bool server) {
        return false;
    }

    internal virtual void SetInterface(bool server, SteamInterface iface) {
        if (!server)
            throw new NotSupportedException();

        Interface = iface;
    }

    internal override void DestroyInterface(bool server) {
        Interface = null;
    }
}