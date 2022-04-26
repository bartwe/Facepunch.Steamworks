using System;

namespace Steamworks.Data;

struct PartnerId_t : IEquatable<PartnerId_t>, IComparable<PartnerId_t> {
    // Name: PartnerId_t, Type: unsigned int
    public uint Value;

    public static implicit operator PartnerId_t(uint value) {
        return new() { Value = value };
    }

    public static implicit operator uint(PartnerId_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((PartnerId_t)p);
    }

    public bool Equals(PartnerId_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(PartnerId_t a, PartnerId_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(PartnerId_t a, PartnerId_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(PartnerId_t other) {
        return Value.CompareTo(other.Value);
    }
}
