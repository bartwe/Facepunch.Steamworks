using System;

namespace Steamworks.Data;

struct RemotePlaySessionID_t : IEquatable<RemotePlaySessionID_t>, IComparable<RemotePlaySessionID_t> {
    // Name: RemotePlaySessionID_t, Type: unsigned int
    public uint Value;

    public static implicit operator RemotePlaySessionID_t(uint value) {
        return new() { Value = value };
    }

    public static implicit operator uint(RemotePlaySessionID_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((RemotePlaySessionID_t)p);
    }

    public bool Equals(RemotePlaySessionID_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(RemotePlaySessionID_t a, RemotePlaySessionID_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(RemotePlaySessionID_t a, RemotePlaySessionID_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(RemotePlaySessionID_t other) {
        return Value.CompareTo(other.Value);
    }
}