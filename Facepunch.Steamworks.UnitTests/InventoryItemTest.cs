using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steamworks.Data;

namespace Steamworks
{
	[TestClass]
	public class InventoryItemTest
	{
		[TestMethod]
		public void ObjectEqualsNullReturnsFalse()
		{
			Assert.IsFalse( default( InventoryItem ).Equals( (object?)null ) );
		}

		[TestMethod]
		public void ObjectEqualsUnrelatedTypeReturnsFalse()
		{
			Assert.IsFalse( default( InventoryItem ).Equals( new object() ) );
		}

		[TestMethod]
		[DataRow( 0UL, 0UL, true )]
		[DataRow( 42UL, 42UL, true )]
		[DataRow( 42UL, 43UL, false )]
		public void ObjectEqualsBoxedItemComparesIds( ulong id, ulong otherId, bool expected )
		{
			var item = CreateItem( id );
			var other = CreateItem( otherId );

			Assert.AreEqual( expected, item.Equals( (object)other ) );
			Assert.AreEqual( expected, item.Equals( other ) );
		}

		static InventoryItem CreateItem( ulong id )
		{
			object item = default( InventoryItem );
			var idField = typeof( InventoryItem ).GetField( "_id", BindingFlags.Instance | BindingFlags.NonPublic )
				?? throw new InvalidOperationException( "InventoryItem._id field was not found." );
			idField.SetValue( item, (InventoryItemId)id );
			return (InventoryItem)item;
		}
	}
}
