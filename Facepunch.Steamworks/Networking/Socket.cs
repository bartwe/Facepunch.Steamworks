using System.Runtime.InteropServices;

namespace Steamworks.Data {
    [StructLayout(LayoutKind.Sequential)]
    public struct Socket {
        internal uint Id;

        public override string ToString() {
            return Id.ToString();
        }

        public static implicit operator Socket(uint value) {
            return new() { Id = value };
        }

        public static implicit operator uint(Socket value) {
            return value.Id;
        }

        /// <summary>
        ///     Destroy a listen socket.  All the connections that were accepting on the listen
        ///     socket are closed ungracefully.
        /// </summary>
        public bool Close() {
            return SteamNetworkingSockets.Internal.CloseListenSocket(Id);
        }

        public SocketManager Manager {
            get { return SteamNetworkingSockets.GetSocketManager(Id); }
            set { SteamNetworkingSockets.SetSocketManager(Id, value); }
        }
    }
}
