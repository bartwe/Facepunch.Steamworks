using System;

namespace Steamworks.Data;

struct UGCQueryHandle_t : IEquatable<UGCQueryHandle_t>, IComparable<UGCQueryHandle_t> {
    // Name: UGCQueryHandle_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator UGCQueryHandle_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(UGCQueryHandle_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((UGCQueryHandle_t)p);
    }

    public bool Equals(UGCQueryHandle_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(UGCQueryHandle_t a, UGCQueryHandle_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(UGCQueryHandle_t a, UGCQueryHandle_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(UGCQueryHandle_t other) {
        return Value.CompareTo(other.Value);
    }
}