using System;

namespace Steamworks.Data;

struct SNetSocket_t : IEquatable<SNetSocket_t>, IComparable<SNetSocket_t> {
    // Name: SNetSocket_t, Type: unsigned int
    public uint Value;

    public static implicit operator SNetSocket_t(uint value) {
        return new() { Value = value };
    }

    public static implicit operator uint(SNetSocket_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((SNetSocket_t)p);
    }

    public bool Equals(SNetSocket_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(SNetSocket_t a, SNetSocket_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(SNetSocket_t a, SNetSocket_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(SNetSocket_t other) {
        return Value.CompareTo(other.Value);
    }
}
