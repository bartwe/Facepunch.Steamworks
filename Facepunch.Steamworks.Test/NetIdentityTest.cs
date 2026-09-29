using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steamworks.Data;

namespace Steamworks
{
	[TestClass]
	public class NetIdentityTest
	{
		[TestMethod]
		public void IsLocalHost_LocalHostIdentity_ReturnsTrue()
		{
			Assert.IsTrue( NetIdentity.LocalHost.IsLocalHost );
		}

		[TestMethod]
		public void IsLocalHost_IPv4LoopbackIdentity_ReturnsTrue()
		{
			NetIdentity identity = NetAddress.From( "127.0.0.1", 12445 );
			Assert.IsTrue( identity.IsLocalHost );
		}

		[TestMethod]
		public void IsLocalHost_RemoteAddressIdentity_ReturnsFalse()
		{
			NetIdentity identity = NetAddress.From( "192.0.2.1", 12445 );
			Assert.IsFalse( identity.IsLocalHost );
		}

		[TestMethod]
		public void IsLocalHost_DefaultIdentity_ReturnsFalse()
		{
			Assert.IsFalse( default( NetIdentity ).IsLocalHost );
		}
	}
}
