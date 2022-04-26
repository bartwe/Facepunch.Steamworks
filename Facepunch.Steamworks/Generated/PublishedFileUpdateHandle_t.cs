using System;

namespace Steamworks.Data;

struct PublishedFileUpdateHandle_t : IEquatable<PublishedFileUpdateHandle_t>, IComparable<PublishedFileUpdateHandle_t> {
    // Name: PublishedFileUpdateHandle_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator PublishedFileUpdateHandle_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(PublishedFileUpdateHandle_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((PublishedFileUpdateHandle_t)p);
    }

    public bool Equals(PublishedFileUpdateHandle_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(PublishedFileUpdateHandle_t a, PublishedFileUpdateHandle_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(PublishedFileUpdateHandle_t a, PublishedFileUpdateHandle_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(PublishedFileUpdateHandle_t other) {
        return Value.CompareTo(other.Value);
    }
}
