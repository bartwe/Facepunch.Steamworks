namespace Steamworks.Data {
    public struct DepotId {
        public uint Value;

        public static implicit operator DepotId(uint value) {
            return new() { Value = value };
        }

        public static implicit operator DepotId(int value) {
            return new() { Value = (uint)value };
        }

        public static implicit operator uint(DepotId value) {
            return value.Value;
        }

        public override string ToString() {
            return Value.ToString();
        }
    }
}
