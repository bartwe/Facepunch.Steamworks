using System;

namespace Steamworks.ServerList {
    public sealed class Favourites : Base {
        internal override void LaunchQuery() {
            var filters = GetFilters();
            request = Internal.RequestFavoritesServerList(AppId.Value, ref filters, (uint)filters.Length, IntPtr.Zero);
        }
    }
}
