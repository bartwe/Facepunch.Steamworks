using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Steamworks
{
	[TestClass]
	public class InventoryPriceTest
	{
		[ClassInitialize]
		public static void LoadInventoryStub( TestContext context )
		{
			// The resolver and its library must remain available for the test process lifetime.
			var library = NativeLibrary.Load( Path.Combine( AppContext.BaseDirectory, "libinventory_test.so" ) );
			NativeLibrary.SetDllImportResolver( typeof( InventoryDef ).Assembly,
				( name, assembly, searchPath ) => name == "libsteam_api"
					? library
					: throw new InvalidOperationException( $"Unexpected native library: {name}" ) );
		}

		[TestMethod]
		[DataRow( 1, "USD", "en-US", 799, 1299, "$7.99", "$12.99" )]
		[DataRow( 1, "EUR", "de-DE", 799, 1299, "€7,99", "€12,99" )]
		[DataRow( 2, "USD", "en-US", 1299, 1299, "$12.99", "$12.99" )]
		[DataRow( 3, "USD", "en-US", 0, 0, "$0.00", "$0.00" )]
		public void FormatsCurrentAndBasePrices( int definitionId, string currency, string culture,
			int currentPrice, int basePrice, string currentFormatted, string baseFormatted )
		{
			var interfaceField = typeof( SteamSharedClass<SteamInventory> ).GetField( "InterfaceClient", BindingFlags.Static | BindingFlags.NonPublic )
				?? throw new InvalidOperationException( "SteamInventory client interface field was not found." );
			var currencyProperty = typeof( SteamInventory ).GetProperty( nameof( SteamInventory.Currency ) )
				?? throw new InvalidOperationException( "SteamInventory.Currency property was not found." );
			var interfaceType = typeof( SteamInventory ).Assembly.GetType( "Steamworks.ISteamInventory", throwOnError: true )!;
			var originalInterface = interfaceField.GetValue( null );
			var originalCurrency = SteamInventory.Currency;
			var originalCulture = CultureInfo.CurrentCulture;

			try
			{
				interfaceField.SetValue( null, Activator.CreateInstance( interfaceType,
					BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { false }, null ) );
				currencyProperty.SetValue( null, currency );
				CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo( culture );
				var definition = new InventoryDef( definitionId );

				Assert.AreEqual( currentPrice, definition.LocalPrice );
				Assert.AreEqual( basePrice, definition.LocalBasePrice );
				Assert.AreEqual( currentFormatted, definition.LocalPriceFormatted );
				Assert.AreEqual( baseFormatted, definition.LocalBasePriceFormatted );
			}
			finally
			{
				interfaceField.SetValue( null, originalInterface );
				currencyProperty.SetValue( null, originalCurrency );
				CultureInfo.CurrentCulture = originalCulture;
			}
		}
	}
}
