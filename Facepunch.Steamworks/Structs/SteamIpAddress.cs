using System.Net;
using System.Runtime.InteropServices;

namespace Steamworks.Data {
    [StructLayout(LayoutKind.Explicit, Pack = Platform.StructPlatformPackSize)]
    partial struct SteamIPAddress {
        [FieldOffset(0)]
        public uint Ip4Address; // Host Order

        [FieldOffset(16)]
        internal SteamIPType Type; // m_eType ESteamIPType

        public static implicit operator IPAddress(SteamIPAddress value) {
            if (value.Type == SteamIPType.Type4)
                return Utility.Int32ToIp(value.Ip4Address);

            throw new($"Oops - can't convert SteamIPAddress to System.Net.IPAddress because no-one coded support for {value.Type} yet");
        }
    }
}
