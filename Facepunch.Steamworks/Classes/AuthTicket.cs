﻿using System;

namespace Steamworks;

public sealed class AuthTicket : IDisposable {
    public byte[] Data;
    public uint Handle;

    public void Dispose() {
        Cancel();
    }

    /// <summary>
    ///     Cancels a ticket.
    ///     You should cancel your ticket when you close the game or leave a server.
    /// </summary>
    public void Cancel() {
        if (Handle != 0) {
            SteamUser.Internal.CancelAuthTicket(Handle);
        }

        Handle = 0;
        Data = null;
    }
}
