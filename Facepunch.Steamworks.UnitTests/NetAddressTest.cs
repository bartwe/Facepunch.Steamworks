using System.Net;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steamworks.Data;

namespace Steamworks
{
	[TestClass]
	public class NetAddressTest
	{
		[TestMethod]
		public void ClearedAddressReturnsIPv6Any()
		{
			var address = NetAddress.Cleared;
			Assert.IsTrue( address.IsIPv6AllZeros );
			Assert.IsFalse( address.IsLocalHost );
			Assert.AreEqual( (ushort)0, address.Port );
			Assert.AreEqual( IPAddress.IPv6Any, address.Address );
			Assert.AreEqual( AddressFamily.InterNetworkV6, address.Address.AddressFamily );
			CollectionAssert.AreEqual( new byte[16], address.Address.GetAddressBytes() );
		}

		[TestMethod]
		[DataRow( (ushort)5543 )]
		[DataRow( ushort.MaxValue )]
		public void AnyIpAddressReturnsIPv6Any( ushort port )
		{
			var address = NetAddress.AnyIp( port );
			Assert.IsTrue( address.IsIPv6AllZeros );
			Assert.AreEqual( port, address.Port );
			Assert.AreEqual( IPAddress.IPv6Any, address.Address );
			CollectionAssert.AreEqual( new byte[16], address.Address.GetAddressBytes() );
		}

		[TestMethod]
		[DataRow( "0.0.0.0" )]
		[DataRow( "127.0.0.1" )]
		[DataRow( "192.0.2.1" )]
		public void IPv4AddressRoundTrips( string ip )
		{
			var address = NetAddress.From( ip, 12445 );
			Assert.IsTrue( address.IsIPv4 );
			Assert.IsFalse( address.IsIPv6AllZeros );
			Assert.AreEqual( IPAddress.Parse( ip ), address.Address );
			Assert.AreEqual( (ushort)12445, address.Port );
		}
	}
}
