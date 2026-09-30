using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Steamworks
{
	[TestClass]
	public class FileDetailsTest
	{
		static Func<byte[], string> formatSha1 =
			(typeof( SteamApps ).GetMethod( "FormatSha1", BindingFlags.Static | BindingFlags.NonPublic )
				?? throw new InvalidOperationException( "SteamApps.FormatSha1 method was not found." ))
			.CreateDelegate<Func<byte[], string>>();

		[TestMethod]
		[DataRow( "000102030405060708090a0b0c0d0e0f107f80ff" )]
		[DataRow( "0000000000000000000000000000000000000000" )]
		[DataRow( "ffffffffffffffffffffffffffffffffffffffff" )]
		public void FormatsSha1AsFortyLowercaseHexDigits( string expected )
		{
			var actual = formatSha1( Convert.FromHexString( expected ) );

			Assert.AreEqual( expected, actual );
			Assert.AreEqual( 40, actual.Length );
		}
	}
}
