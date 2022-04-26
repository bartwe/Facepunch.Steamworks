﻿using System;

namespace Steamworks;

abstract class SteamInterface {
    public IntPtr Self;
    public IntPtr SelfGlobal;
    public IntPtr SelfServer;
    public IntPtr SelfClient;

    public bool IsValid => Self != IntPtr.Zero;

    public bool IsServer { get; private set; }

    public virtual IntPtr GetUserInterfacePointer() {
        return IntPtr.Zero;
    }

    public virtual IntPtr GetServerInterfacePointer() {
        return IntPtr.Zero;
    }

    public virtual IntPtr GetGlobalInterfacePointer() {
        return IntPtr.Zero;
    }

    internal void SetupInterface(bool gameServer) {
        if (Self != IntPtr.Zero)
            return;

        IsServer = gameServer;
        SelfGlobal = GetGlobalInterfacePointer();
        Self = SelfGlobal;

        if (Self != IntPtr.Zero)
            return;

        if (gameServer) {
            SelfServer = GetServerInterfacePointer();
            Self = SelfServer;
        }
        else {
            SelfClient = GetUserInterfacePointer();
            Self = SelfClient;
        }
    }

    internal void ShutdownInterface() {
        Self = IntPtr.Zero;
    }
}