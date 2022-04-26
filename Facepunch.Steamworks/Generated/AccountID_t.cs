using System;

namespace Steamworks.Data;

struct AccountID_t : IEquatable<AccountID_t>, IComparable<AccountID_t> {
    // Name: AccountID_t, Type: unsigned int
    public uint Value;

    public static implicit operator AccountID_t(uint value) {
        return new() { Value = value };
    }

    public static implicit operator uint(AccountID_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((AccountID_t)p);
    }

    public bool Equals(AccountID_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(AccountID_t a, AccountID_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(AccountID_t a, AccountID_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(AccountID_t other) {
        return Value.CompareTo(other.Value);
    }
}