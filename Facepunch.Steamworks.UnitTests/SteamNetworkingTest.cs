using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Steamworks
{
	[TestClass]
	public class SteamNetworkingTest
	{
		[TestMethod]
		[DataRow( 0, 1 )]
		[DataRow( 1, 2 )]
		[DataRow( 1, int.MaxValue )]
		public void RejectsOversizedPacketBeforeAccessingSteam( int bufferLength, int length )
		{
			var data = new byte[bufferLength];
			// Steam is not initialized: validation must precede native-interface access.
			var exception = Assert.ThrowsExactly<ArgumentOutOfRangeException>(
				() => SteamNetworking.SendP2PPacket( default, data, length: length ) );
			Assert.AreEqual( "length", exception.ParamName );
		}
	}
}
