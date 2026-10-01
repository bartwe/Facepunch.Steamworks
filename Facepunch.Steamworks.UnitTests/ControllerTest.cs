using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Steamworks
{
	[TestClass]
	public class ControllerTest
	{
		[TestMethod]
		[DataRow( null )]
		[DataRow( 3 )]
		[DataRow( "controller" )]
		public void EqualsNullOrDifferentTypeReturnsFalse( object? other )
		{
			object controller = default( Controller );
			Assert.IsFalse( controller.Equals( other ) );
		}

		[TestMethod]
		public void EqualsEqualBoxedControllerReturnsTrue()
		{
			object controller = default( Controller );
			object other = default( Controller );
			Assert.IsTrue( controller.Equals( other ) );
		}
	}
}
