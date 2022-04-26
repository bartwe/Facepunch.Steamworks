using System;

namespace Steamworks.Data;

struct UGCFileWriteStreamHandle_t : IEquatable<UGCFileWriteStreamHandle_t>, IComparable<UGCFileWriteStreamHandle_t> {
    // Name: UGCFileWriteStreamHandle_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator UGCFileWriteStreamHandle_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(UGCFileWriteStreamHandle_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((UGCFileWriteStreamHandle_t)p);
    }

    public bool Equals(UGCFileWriteStreamHandle_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(UGCFileWriteStreamHandle_t a, UGCFileWriteStreamHandle_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(UGCFileWriteStreamHandle_t a, UGCFileWriteStreamHandle_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(UGCFileWriteStreamHandle_t other) {
        return Value.CompareTo(other.Value);
    }
}
