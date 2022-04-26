using System;

namespace Steamworks.Data;

struct GID_t : IEquatable<GID_t>, IComparable<GID_t> {
    // Name: GID_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator GID_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(GID_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((GID_t)p);
    }

    public bool Equals(GID_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(GID_t a, GID_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(GID_t a, GID_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(GID_t other) {
        return Value.CompareTo(other.Value);
    }
}