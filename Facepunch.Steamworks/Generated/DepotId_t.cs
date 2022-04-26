using System;

namespace Steamworks.Data;

struct DepotId_t : IEquatable<DepotId_t>, IComparable<DepotId_t> {
    // Name: DepotId_t, Type: unsigned int
    public uint Value;

    public static implicit operator DepotId_t(uint value) {
        return new() { Value = value };
    }

    public static implicit operator uint(DepotId_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((DepotId_t)p);
    }

    public bool Equals(DepotId_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(DepotId_t a, DepotId_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(DepotId_t a, DepotId_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(DepotId_t other) {
        return Value.CompareTo(other.Value);
    }
}