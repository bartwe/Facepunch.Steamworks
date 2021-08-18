namespace Steamworks {
    public struct SteamId {
        public ulong Value;

        public static implicit operator SteamId(ulong value) {
            return new() { Value = value };
        }

        public static implicit operator ulong(SteamId value) {
            return value.Value;
        }

        public override string ToString() {
            return Value.ToString();
        }

        public uint AccountId {
            get { return (uint)(Value & 0xFFFFFFFFul); }
        }

        public bool IsValid {
            get { return Value != default; }
        }
    }
}
