using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Steamworks
{
	[TestClass]
	public class IpListTest
	{
		static FieldInfo initializedField = typeof( SteamClient ).GetField( "initialized", BindingFlags.Static | BindingFlags.NonPublic )
			?? throw new InvalidOperationException( "SteamClient.initialized field was not found." );
		static Type matchmakingType = typeof( SteamClient ).Assembly.GetType( "Steamworks.SteamMatchmakingServers", throwOnError: true )!;
		static FieldInfo interfaceField = typeof( SteamClientClass<> ).MakeGenericType( matchmakingType )
			.GetField( "Interface", BindingFlags.Static | BindingFlags.NonPublic )
			?? throw new InvalidOperationException( "SteamMatchmakingServers interface field was not found." );
		object? originalInterface;
		object? originalInitialized;

		[ClassInitialize]
		public static void LoadStub( TestContext context )
		{
			if ( !OperatingSystem.IsLinux() )
				Assert.Inconclusive( "The server-list native API stub requires Linux and a C compiler." );

			var handle = NativeLibrary.Load( Path.Combine( AppContext.BaseDirectory, "libserver_list_stub.so" ) );
			NativeLibrary.SetDllImportResolver( typeof( SteamClient ).Assembly, ( name, assembly, path ) =>
				name == "libsteam_api" ? handle : throw new DllNotFoundException( name ) );
		}

		[TestInitialize]
		public void SetUp()
		{
			originalInterface = interfaceField.GetValue( null );
			originalInitialized = initializedField.GetValue( null );
			Test_Reset();
			var apiType = typeof( SteamClient ).Assembly.GetType( "Steamworks.ISteamMatchmakingServers", throwOnError: true )!;
			var api = Activator.CreateInstance( apiType, BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { false }, null );
			interfaceField.SetValue( null, api );
			initializedField.SetValue( null, true );
		}

		[TestCleanup]
		public void TearDown()
		{
			interfaceField.SetValue( null, originalInterface );
			initializedField.SetValue( null, originalInitialized );
			var state = Test_GetState();
			Assert.AreEqual( state.Requests, state.Releases, "Every request must be released." );
		}

		[TestMethod]
		[DataRow( false )]
		[DataRow( true )]
		public async Task CancelInterruptsPendingQuery( bool cancelOnWorker )
		{
			using var list = new ServerList.IpList( Enumerable.Repeat( "127.0.0.1", 17 ) );
			int changes = 0;
			list.OnChanges += () => changes++;
			var query = list.RunQueryAsync( 10 );
			try
			{
				Assert.AreEqual( 1, Test_GetState().Requests );
				Assert.IsFalse( query.IsCompleted, "The inner query must be pending before cancellation." );
				if ( cancelOnWorker )
					await Task.Run( list.Cancel );
				else
					list.Cancel();

				Assert.IsFalse( await query.WaitAsync( TimeSpan.FromSeconds( 2 ) ) );
				var state = Test_GetState();
				Assert.AreEqual( 1, state.Requests, "Cancellation must prevent the second block." );
				Assert.AreEqual( 1, state.Releases );
				Assert.IsTrue( state.Cancellations >= 1 );
				Assert.AreEqual( 0, changes );
				list.Cancel();
				Assert.AreEqual( state.Cancellations, Test_GetState().Cancellations, "Cancel must not use a released request." );
			}
			finally
			{
				// Drain the real async loop even when the cancellation regression fails.
				Test_CompleteQueries();
				await query.WaitAsync( TimeSpan.FromSeconds( 2 ) );
			}
		}

		[TestMethod]
		public async Task CompletedQueriesContinueThroughAllBlocks()
		{
			Test_CompleteQueries();
			using var list = new ServerList.IpList( Enumerable.Repeat( "127.0.0.1", 17 ) );
			int changes = 0;
			list.OnChanges += () => changes++;
			Assert.IsTrue( await list.RunQueryAsync() );
			var state = Test_GetState();
			Assert.AreEqual( 2, state.Requests );
			Assert.AreEqual( 2, state.Releases );
			Assert.AreEqual( 2, changes );
			list.Cancel();
			Assert.AreEqual( state.Cancellations, Test_GetState().Cancellations );
		}

		[TestMethod]
		public async Task CancelBetweenBlocksDoesNotStartAnotherQuery()
		{
			Test_CompleteQueries();
			using var list = new ServerList.IpList( Enumerable.Repeat( "127.0.0.1", 17 ) );
			list.OnChanges += list.Cancel;
			Assert.IsFalse( await list.RunQueryAsync() );
			Assert.AreEqual( 1, Test_GetState().Requests );
		}

		[TestMethod]
		public async Task CancelWithoutAnActiveQueryDoesNotCallSteam()
		{
			using var list = new ServerList.IpList( Array.Empty<string>() );
			list.Cancel();
			Assert.IsTrue( await list.RunQueryAsync() );
			Assert.AreEqual( 0, Test_GetState().Requests );
			Assert.AreEqual( 0, Test_GetState().Cancellations );
		}

		[StructLayout( LayoutKind.Sequential )]
		struct NativeState
		{
			public int Requests;
			public int Cancellations;
			public int Releases;
		}

		[DllImport( "libserver_list_stub", CallingConvention = CallingConvention.Cdecl )]
		static extern void Test_Reset();

		[DllImport( "libserver_list_stub", CallingConvention = CallingConvention.Cdecl )]
		static extern void Test_CompleteQueries();

		[DllImport( "libserver_list_stub", CallingConvention = CallingConvention.Cdecl )]
		static extern NativeState Test_GetState();
	}
}
