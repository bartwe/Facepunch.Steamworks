using System;

namespace Steamworks.Data;

struct SiteId_t : IEquatable<SiteId_t>, IComparable<SiteId_t> {
    // Name: SiteId_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator SiteId_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(SiteId_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((SiteId_t)p);
    }

    public bool Equals(SiteId_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(SiteId_t a, SiteId_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(SiteId_t a, SiteId_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(SiteId_t other) {
        return Value.CompareTo(other.Value);
    }
}