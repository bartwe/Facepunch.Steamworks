﻿using System;

namespace Steamworks.ServerList
{
	public class Friends : Base
	{
		internal override void LaunchQuery()
		{
			var filters = GetFilters();
			request = Internal.RequestFriendsServerList( AppId.Value, ref filters, (uint)filters.Length, IntPtr.Zero );
		}
	}
}