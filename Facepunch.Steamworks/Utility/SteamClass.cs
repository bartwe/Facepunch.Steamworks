﻿namespace Steamworks;

public abstract class SteamClass {
    internal abstract bool InitializeInterface(bool server);
    internal abstract void DestroyInterface(bool server);
}