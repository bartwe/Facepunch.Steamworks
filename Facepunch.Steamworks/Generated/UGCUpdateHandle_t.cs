using System;

namespace Steamworks.Data;

struct UGCUpdateHandle_t : IEquatable<UGCUpdateHandle_t>, IComparable<UGCUpdateHandle_t> {
    // Name: UGCUpdateHandle_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator UGCUpdateHandle_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(UGCUpdateHandle_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((UGCUpdateHandle_t)p);
    }

    public bool Equals(UGCUpdateHandle_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(UGCUpdateHandle_t a, UGCUpdateHandle_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(UGCUpdateHandle_t a, UGCUpdateHandle_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(UGCUpdateHandle_t other) {
        return Value.CompareTo(other.Value);
    }
}
