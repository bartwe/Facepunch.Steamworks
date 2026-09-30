using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: DoNotParallelize]

namespace Steamworks
{
	[TestClass]
	public class InventoryResultTest
	{
		static FieldInfo interfaceField = typeof( SteamSharedClass<SteamInventory> ).GetField( "InterfaceClient", BindingFlags.Static | BindingFlags.NonPublic )
			?? throw new InvalidOperationException( "Steam inventory client interface field was not found." );
		object? originalInterface;
		InventoryResult resultField;

		[DllImport( "libsteam_api", CallingConvention = CallingConvention.Cdecl )]
		static extern void ResetInventoryStub( int handle );

		[DllImport( "libsteam_api", CallingConvention = CallingConvention.Cdecl )]
		static extern int GetDestroyCount();

		[DllImport( "libsteam_api", CallingConvention = CallingConvention.Cdecl )]
		static extern int GetLastDestroyedHandle();

		[TestInitialize]
		public void InstallInventoryStub()
		{
			originalInterface = interfaceField.GetValue( null );
			var interfaceType = typeof( SteamInventory ).Assembly.GetType( "Steamworks.ISteamInventory", throwOnError: true )!;
			var inventoryInterface = Activator.CreateInstance( interfaceType, BindingFlags.Instance | BindingFlags.NonPublic,
				binder: null, args: new object[] { false }, culture: null );
			Assert.IsNotNull( inventoryInterface );
			interfaceField.SetValue( null, inventoryInterface );
		}

		[TestCleanup]
		public void RestoreInventoryInterface()
		{
			interfaceField.SetValue( null, originalInterface );
		}

		[TestMethod]
		[DataRow( 0 )]
		[DataRow( 42 )]
		public async Task DisposeLocalTwiceDestroysHandleOnce( int handle )
		{
			ResetInventoryStub( handle );
			var optionalResult = await SteamInventory.GetAllItemsAsync();
			Assert.IsTrue( optionalResult.HasValue );
			var result = optionalResult.Value;

			result.Dispose();
			result.Dispose();

			Assert.AreEqual( 1, GetDestroyCount() );
			Assert.AreEqual( handle, GetLastDestroyedHandle() );
		}

		[TestMethod]
		[DataRow( 0 )]
		[DataRow( 42 )]
		public async Task DisposeFieldTwiceDestroysHandleOnce( int handle )
		{
			ResetInventoryStub( handle );
			var optionalResult = await SteamInventory.GetAllItemsAsync();
			Assert.IsTrue( optionalResult.HasValue );
			resultField = optionalResult.Value;

			resultField.Dispose();
			resultField.Dispose();

			Assert.AreEqual( 1, GetDestroyCount() );
			Assert.AreEqual( handle, GetLastDestroyedHandle() );
		}

		[TestMethod]
		public async Task DisposeInvalidHandleDoesNotDestroyResult()
		{
			// Deliberately supply the invalid sentinel to exercise the existing guard.
			ResetInventoryStub( -1 );
			var optionalResult = await SteamInventory.GetAllItemsAsync();
			Assert.IsTrue( optionalResult.HasValue );
			var result = optionalResult.Value;

			result.Dispose();
			result.Dispose();

			Assert.AreEqual( 0, GetDestroyCount() );
		}
	}
}
