using System;

namespace Steamworks.Data;

struct InputActionSetHandle_t : IEquatable<InputActionSetHandle_t>, IComparable<InputActionSetHandle_t> {
    // Name: InputActionSetHandle_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator InputActionSetHandle_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(InputActionSetHandle_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((InputActionSetHandle_t)p);
    }

    public bool Equals(InputActionSetHandle_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(InputActionSetHandle_t a, InputActionSetHandle_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(InputActionSetHandle_t a, InputActionSetHandle_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(InputActionSetHandle_t other) {
        return Value.CompareTo(other.Value);
    }
}