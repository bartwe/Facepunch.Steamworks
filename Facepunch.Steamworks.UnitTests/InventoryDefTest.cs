using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Steamworks
{
	[TestClass]
	public class InventoryDefTest
	{
		static FieldInfo propertiesField = typeof( InventoryDef ).GetField( "_properties", BindingFlags.Instance | BindingFlags.NonPublic )
			?? throw new InvalidOperationException( "InventoryDef._properties field was not found." );

		[TestMethod]
		[DataRow( null, false )]
		[DataRow( "", false )]
		[DataRow( "0", false )]
		[DataRow( "False", false )]
		[DataRow( "false", false )]
		[DataRow( "FALSE", false )]
		[DataRow( "1", true )]
		[DataRow( "True", true )]
		[DataRow( "true", true )]
		[DataRow( "TRUE", true )]
		[DataRow( "other", true )]
		public void BooleanPropertiesHandleLookupValues( string? value, bool expected )
		{
			var definition = new InventoryDef( 1 );
			// Supply GetProperty's result without initializing Steam, including null for a failed lookup.
			propertiesField.SetValue( definition, new Dictionary<string, string?>
			{
				["custom_bool"] = value,
				["marketable"] = value,
				["tradable"] = value
			} );

			Assert.AreEqual( value, definition.GetProperty( "custom_bool" ) );
			Assert.AreEqual( expected, definition.GetBoolProperty( "custom_bool" ) );
			Assert.AreEqual( expected, definition.Marketable );
			Assert.AreEqual( expected, definition.Tradable );
		}
	}
}
