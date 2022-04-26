using System;

namespace Steamworks.Data;

struct BundleId_t : IEquatable<BundleId_t>, IComparable<BundleId_t> {
    // Name: BundleId_t, Type: unsigned int
    public uint Value;

    public static implicit operator BundleId_t(uint value) {
        return new() { Value = value };
    }

    public static implicit operator uint(BundleId_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((BundleId_t)p);
    }

    public bool Equals(BundleId_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(BundleId_t a, BundleId_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(BundleId_t a, BundleId_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(BundleId_t other) {
        return Value.CompareTo(other.Value);
    }
}
