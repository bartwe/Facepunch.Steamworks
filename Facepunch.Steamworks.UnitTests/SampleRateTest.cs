using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: DoNotParallelize]

namespace Steamworks
{
	[TestClass]
	public class SampleRateTest
	{
		static FieldInfo sampleRateField = typeof( SteamUser ).GetField( "sampleRate", BindingFlags.Static | BindingFlags.NonPublic )
			?? throw new InvalidOperationException( "SteamUser.sampleRate field was not found." );
		uint originalSampleRate;

		[TestInitialize]
		public void SaveSampleRate()
		{
			originalSampleRate = SteamUser.SampleRate;
			SteamUser.SampleRate = 48000;
		}

		[TestCleanup]
		public void RestoreSampleRate()
		{
			// Restore even when a regression leaves the setter unable to accept valid values.
			sampleRateField.SetValue( null, originalSampleRate );
		}

		[TestMethod]
		[DataRow( 11025U )]
		[DataRow( 22050U )]
		[DataRow( 48000U )]
		public void AcceptsSupportedRates( uint rate )
		{
			SteamUser.SampleRate = rate;
			Assert.AreEqual( rate, SteamUser.SampleRate );
		}

		[TestMethod]
		[DataRow( 0U )]
		[DataRow( 11024U )]
		[DataRow( 48001U )]
		[DataRow( uint.MaxValue )]
		public void RejectsUnsupportedRatesWithoutChangingState( uint rate )
		{
			Assert.ThrowsExactly<Exception>( () => SteamUser.SampleRate = rate );
			Assert.AreEqual( 48000U, SteamUser.SampleRate );
			SteamUser.SampleRate = 22050;
			Assert.AreEqual( 22050U, SteamUser.SampleRate );
		}

		[TestMethod]
		[DataRow( 11024U )]
		[DataRow( 48001U )]
		public void AcceptsSupportedRateWhenStoredRateIsInvalid( uint storedRate )
		{
			sampleRateField.SetValue( null, storedRate );
			SteamUser.SampleRate = 48000;
			Assert.AreEqual( 48000U, SteamUser.SampleRate );
		}
	}
}
