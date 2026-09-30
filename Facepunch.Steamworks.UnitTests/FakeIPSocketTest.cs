using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Steamworks
{
	[TestClass]
	public class FakeIPSocketTest
	{
		static FieldInfo interfaceField = typeof( SteamSharedClass<SteamNetworkingSockets> ).GetField(
			"InterfaceClient", BindingFlags.Static | BindingFlags.NonPublic )
			?? throw new InvalidOperationException( "Networking client interface field was not found." );
		static Dictionary<uint, SocketManager> socketManagers =
			(Dictionary<uint, SocketManager>)(typeof( SteamNetworkingSockets ).GetField(
				"SocketInterfaces", BindingFlags.Static | BindingFlags.NonPublic )?.GetValue( null )
				?? throw new InvalidOperationException( "Socket manager registry was not found." ));
		static object? originalInterface;

		[DllImport( "libsteam_api", EntryPoint = "FakeIPTest_GetLastPortIndex", CallingConvention = CallingConvention.Cdecl )]
		static extern int GetLastPortIndex();

		[ClassInitialize]
		public static void Initialize( TestContext context )
		{
			if ( !OperatingSystem.IsLinux() )
				Assert.Inconclusive( "The Fake IP native test shim is built only on Linux." );

			originalInterface = interfaceField.GetValue( null );
			var interfaceType = typeof( SteamNetworkingSockets ).Assembly.GetType( "Steamworks.ISteamNetworkingSockets", throwOnError: true )!;
			var sockets = Activator.CreateInstance( interfaceType, BindingFlags.Instance | BindingFlags.NonPublic,
				binder: null, args: new object[] { false }, culture: null )
				?? throw new InvalidOperationException( "Could not create the networking interface." );
			interfaceField.SetValue( null, sockets );
		}

		[ClassCleanup]
		public static void Cleanup()
		{
			interfaceField.SetValue( null, originalInterface );
		}

		[TestInitialize]
		public void ReservePorts()
		{
			Assert.IsTrue( SteamNetworkingSockets.RequestFakeIP( 4 ) );
		}

		[TestMethod]
		[DataRow( 0 )]
		[DataRow( 1 )]
		[DataRow( 3 )]
		public void GenericOverloadForwardsPortIndex( int fakePortIndex )
		{
			CheckSocket( SteamNetworkingSockets.CreateRelaySocketFakeIP<TestSocketManager>( fakePortIndex ), fakePortIndex, null );
		}

		[TestMethod]
		[DataRow( 0 )]
		[DataRow( 1 )]
		[DataRow( 3 )]
		public void InterfaceOverloadForwardsPortIndex( int fakePortIndex )
		{
			var callbacks = new TestSocketManager();
			CheckSocket( SteamNetworkingSockets.CreateRelaySocketFakeIP( fakePortIndex, callbacks ), fakePortIndex, callbacks );
		}

		[TestMethod]
		public void GenericOverloadDefaultsToFirstPort()
		{
			CheckSocket( SteamNetworkingSockets.CreateRelaySocketFakeIP<TestSocketManager>(), 0, null );
		}

		static void CheckSocket( SocketManager manager, int expectedPortIndex, ISocketManager? expectedInterface )
		{
			uint socket = manager.Socket;
			try
			{
				Assert.AreEqual( expectedPortIndex, GetLastPortIndex() );
				Assert.AreSame( manager, manager.Socket.Manager );
				Assert.AreSame( expectedInterface, manager.Interface );
			}
			finally
			{
				manager.Close();
				socketManagers.Remove( socket );
			}
		}

		public class TestSocketManager : SocketManager, ISocketManager { }
	}
}
