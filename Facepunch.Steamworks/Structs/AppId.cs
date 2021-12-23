namespace Steamworks;

public struct AppId {
    public uint Value;

    public override string ToString() {
        return Value.ToString();
    }

    public static implicit operator AppId(uint value) {
        return new() { Value = value };
    }

    public static implicit operator AppId(int value) {
        return new() { Value = (uint)value };
    }

    public static implicit operator uint(AppId value) {
        return value.Value;
    }
}
