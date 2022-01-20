using System;

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

public abstract class SteamClass {
    internal abstract bool InitializeInterface(bool server);
    internal abstract void DestroyInterface(bool server);
}

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

public abstract class SteamClientClass<T> : SteamClass {
    internal static SteamInterface Interface;

    internal override bool InitializeInterface(bool server) {
        return false;
    }

    internal virtual void SetInterface(bool server, SteamInterface iface) {
        if (server)
            throw new NotSupportedException();

        Interface = iface;
    }

    internal override void DestroyInterface(bool server) {
        Interface = null;
    }
}

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
