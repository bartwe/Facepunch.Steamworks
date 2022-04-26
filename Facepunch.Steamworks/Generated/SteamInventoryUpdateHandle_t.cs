using System;

namespace Steamworks.Data;

struct SteamInventoryUpdateHandle_t : IEquatable<SteamInventoryUpdateHandle_t>, IComparable<SteamInventoryUpdateHandle_t> {
    // Name: SteamInventoryUpdateHandle_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator SteamInventoryUpdateHandle_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(SteamInventoryUpdateHandle_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((SteamInventoryUpdateHandle_t)p);
    }

    public bool Equals(SteamInventoryUpdateHandle_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(SteamInventoryUpdateHandle_t a, SteamInventoryUpdateHandle_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(SteamInventoryUpdateHandle_t a, SteamInventoryUpdateHandle_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(SteamInventoryUpdateHandle_t other) {
        return Value.CompareTo(other.Value);
    }
}