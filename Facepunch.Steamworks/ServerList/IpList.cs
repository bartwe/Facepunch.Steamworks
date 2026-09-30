using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steamworks.ServerList
{
	public class IpList : Internet
	{
		public List<string> Ips = new List<string>();
		bool wantsCancel;
		object queryLock = new object();
		Internet activeQuery;

		public IpList( IEnumerable<string> list )
		{
			Ips.AddRange( list );
		}

		public IpList( params string[] list )
		{
			Ips.AddRange( list );
		}

		public override async Task<bool> RunQueryAsync( float timeoutSeconds = 10 )
		{
			int blockSize = 16;
			int pointer = 0;

			var ips = Ips.ToArray();

			while ( true )
			{
				var sublist = ips.Skip( pointer ).Take( blockSize );
				if ( sublist.Count() == 0 )
					break;

				using ( var list = new ServerList.Internet() )
				{
					list.AddFilter( "or", sublist.Count().ToString() );

					foreach ( var server in sublist )
					{
						list.AddFilter( "gameaddr", server );
					}

					try
					{
						Task<bool> query;
						lock ( queryLock )
						{
							if ( wantsCancel )
								return false;

							query = list.RunQueryAsync( timeoutSeconds );
							activeQuery = list;
						}

						await query;
					}
					finally
					{
						lock ( queryLock )
						{
							activeQuery = null;
						}
					}

					if ( wantsCancel )
						return false;

					Responsive.AddRange( list.Responsive );
					Responsive = Responsive.Distinct().ToList();
					Unresponsive.AddRange( list.Unresponsive );
					Unresponsive = Unresponsive.Distinct().ToList();
				}

				pointer += sublist.Count();

				InvokeChanges();
			}

			return true;
		}

		public override void Cancel()
		{
			lock ( queryLock )
			{
				wantsCancel = true;
				if ( activeQuery != null && activeQuery.request.Value != IntPtr.Zero )
					activeQuery.Cancel();
			}
		}
	}
}
