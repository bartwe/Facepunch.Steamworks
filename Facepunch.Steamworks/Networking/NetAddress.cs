﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Explicit, Size = 18, Pack = 1)]
public partial struct NetAddress {
    [FieldOffset(0)]
    internal IPV4 ip;

    [FieldOffset(16)]
    internal ushort port;

    internal struct IPV4 {
        internal ulong m_8zeros;
        internal ushort m_0000;
        internal ushort m_ffff;
        internal byte ip0;
        internal byte ip1;
        internal byte ip2;
        internal byte ip3;
    }

    /// <summary>
    ///     The Port. This is redundant documentation.
    /// </summary>
    public ushort Port => port;

    /// <summary>
    ///     Any IP, specific port
    /// </summary>
    public static NetAddress AnyIp(ushort port) {
        var addr = Cleared;
        addr.port = port;
        return addr;
    }

    /// <summary>
    ///     Localhost IP, specific port
    /// </summary>
    public static NetAddress LocalHost(ushort port) {
        var local = Cleared;
        InternalSetIPv6LocalHost(ref local, port);
        return local;
    }

    /// <summary>
    ///     Specific IP, specific port
    /// </summary>
    public static NetAddress From(string addrStr, ushort port) {
        return From(IPAddress.Parse(addrStr), port);
    }

    /// <summary>
    ///     Specific IP, specific port
    /// </summary>
    public static NetAddress From(IPAddress address, ushort port) {
        _ = address.GetAddressBytes();

        if (address.AddressFamily == AddressFamily.InterNetwork) {
            var local = Cleared;
            InternalSetIPv4(ref local, address.IpToInt32(), port);
            return local;
        }

        throw new NotImplementedException("Oops - no IPV6 support yet?");
    }

    /// <summary>
    ///     Set everything to zero
    /// </summary>
    public static NetAddress Cleared {
        get {
            NetAddress self = default;
            InternalClear(ref self);
            return self;
        }
    }

    /// <summary>
    ///     Return true if the IP is ::0.  (Doesn't check port.)
    /// </summary>
    public bool IsIPv6AllZeros {
        get {
            var self = this;
            return InternalIsIPv6AllZeros(ref self);
        }
    }

    /// <summary>
    ///     Return true if IP is mapped IPv4
    /// </summary>
    public bool IsIPv4 {
        get {
            var self = this;
            return InternalIsIPv4(ref self);
        }
    }

    /// <summary>
    ///     Return true if this identity is localhost.  (Either IPv6 ::1, or IPv4 127.0.0.1)
    /// </summary>
    public bool IsLocalHost {
        get {
            var self = this;
            return InternalIsLocalHost(ref self);
        }
    }

    /// <summary>
    ///     Get the Address section
    /// </summary>
    public IPAddress Address {
        get {
            if (IsIPv4) {
                var self = this;
                var ip = InternalGetIPv4(ref self);
                return Utility.Int32ToIp(ip);
            }

            if (IsIPv6AllZeros) {
                return IPAddress.IPv6Loopback;
            }

            throw new NotImplementedException("Oops - no IPV6 support yet?");
        }
    }

    public override string ToString() {
        var ptr = Helpers.TakeMemory();
        var self = this;
        InternalToString(ref self, ptr, Helpers.MemoryBufferSize, true);
        return Helpers.MemoryToString(ptr);
    }
}
