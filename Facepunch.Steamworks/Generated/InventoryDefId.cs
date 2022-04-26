using System;

namespace Steamworks.Data;

public struct InventoryDefId : IEquatable<InventoryDefId>, IComparable<InventoryDefId> {
    // Name: SteamItemDef_t, Type: int
    public int Value;

    public static implicit operator InventoryDefId(int value) {
        return new() { Value = value };
    }

    public static implicit operator int(InventoryDefId value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((InventoryDefId)p);
    }

    public bool Equals(InventoryDefId p) {
        return p.Value == Value;
    }

    public static bool operator ==(InventoryDefId a, InventoryDefId b) {
        return a.Equals(b);
    }

    public static bool operator !=(InventoryDefId a, InventoryDefId b) {
        return !a.Equals(b);
    }

    public int CompareTo(InventoryDefId other) {
        return Value.CompareTo(other.Value);
    }
}
