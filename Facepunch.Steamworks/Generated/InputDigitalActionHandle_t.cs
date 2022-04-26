using System;

namespace Steamworks.Data;

struct InputDigitalActionHandle_t : IEquatable<InputDigitalActionHandle_t>, IComparable<InputDigitalActionHandle_t> {
    // Name: InputDigitalActionHandle_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator InputDigitalActionHandle_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(InputDigitalActionHandle_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((InputDigitalActionHandle_t)p);
    }

    public bool Equals(InputDigitalActionHandle_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(InputDigitalActionHandle_t a, InputDigitalActionHandle_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(InputDigitalActionHandle_t a, InputDigitalActionHandle_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(InputDigitalActionHandle_t other) {
        return Value.CompareTo(other.Value);
    }
}