using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steamworks.Data;

namespace Steamworks
{
	[TestClass]
	public class PublishedFileIdTest
	{
		[TestMethod]
		[DataRow( 0UL )]
		[DataRow( 1UL )]
		[DataRow( ulong.MaxValue )]
		public void ObjectEqualsRejectsOtherTypes( ulong value )
		{
			object id = (PublishedFileId)value;

			Assert.IsFalse( id.Equals( new object() ) );
			Assert.IsFalse( id.Equals( value ) );
			Assert.IsFalse( id.Equals( (SteamId)value ) );
		}

		[TestMethod]
		[DataRow( 0UL )]
		[DataRow( 1UL )]
		[DataRow( ulong.MaxValue )]
		public void ObjectEqualsRejectsNull( ulong value )
		{
			object id = (PublishedFileId)value;

			Assert.IsFalse( id.Equals( null ) );
		}

		[TestMethod]
		[DataRow( 0UL, 0UL, true )]
		[DataRow( 1UL, 1UL, true )]
		[DataRow( ulong.MaxValue, ulong.MaxValue, true )]
		[DataRow( 0UL, 1UL, false )]
		[DataRow( 1UL, 0UL, false )]
		[DataRow( 1UL, ulong.MaxValue, false )]
		public void ObjectEqualsComparesValues( ulong value, ulong otherValue, bool expected )
		{
			PublishedFileId id = value;
			PublishedFileId other = otherValue;

			Assert.AreEqual( expected, ((object)id).Equals( other ) );
			Assert.AreEqual( expected, id.Equals( other ) );
			Assert.AreEqual( expected, id == other );
			Assert.AreEqual( !expected, id != other );
		}
	}
}
