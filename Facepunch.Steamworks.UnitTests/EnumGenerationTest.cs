using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Generator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Steamworks
{
	[TestClass]
	public class EnumGenerationTest
	{
		static readonly JsonSerializerOptions jsonOptions = new() { PropertyNameCaseInsensitive = true };
		static readonly string[] ugcReadActionNames = { "ContinueReadingUntilFinished", "ContinueReading", "Close" };
		static readonly int[] ugcReadActionValues = { 0, 1, 2 };

		[TestMethod]
		[DataRow( "EUGCReadAction", new[] { "ContinueReadingUntilFinished = 0,", "ContinueReading = 1,", "Close = 2," } )]
		[DataRow( "EUserHasLicenseForAppResult", new[] { "HasLicense = 0,", "DoesNotHaveLicense = 1,", "NoAuth = 2," } )]
		[DataRow( "ESteamIPType", new[] { "Type4 = 0,", "Type6 = 1," } )]
		public void GeneratesCompleteMemberNames( string enumName, string[] expectedMembers )
		{
			var sdk = JsonSerializer.Deserialize<SteamApiDefinition>(
				File.ReadAllText( Path.Combine( AppContext.BaseDirectory, "steam_api.json" ) ),
				jsonOptions )
				?? throw new InvalidOperationException( "Failed to deserialize steam_api.json." );
			var definition = new SteamApiDefinition
			{
				enums = new[] { sdk.enums.Single( e => e.Name == enumName ) },
				typedefs = new(),
				structs = new(),
				callback_structs = new(),
				Consts = new(),
				Interfaces = Array.Empty<SteamApiDefinition.Interface>()
			};
			var directory = Directory.CreateTempSubdirectory( "SteamEnumTest-" );
			try
			{
				new CodeWriter( definition ).ToFolder( directory.FullName + Path.DirectorySeparatorChar );
				var members = File.ReadAllLines( Path.Combine( directory.FullName, "SteamEnums.cs" ) )
					.Select( line => line.Trim() ).Where( line => line.Contains( " = ", StringComparison.Ordinal ) ).ToArray();
				CollectionAssert.AreEqual( expectedMembers, members );
			}
			finally
			{
				directory.Delete( recursive: true );
			}
		}

		[TestMethod]
		public void CompiledUGCReadActionHasCompleteNamesAndNativeValues()
		{
			var enumType = typeof( SteamUser ).Assembly.GetType( "Steamworks.UGCReadAction", throwOnError: true )!;
			Assert.AreEqual( typeof( int ), Enum.GetUnderlyingType( enumType ) );
			CollectionAssert.AreEqual( ugcReadActionNames, Enum.GetNames( enumType ) );
			CollectionAssert.AreEqual( ugcReadActionValues, Enum.GetValues( enumType ).Cast<int>().ToArray() );
		}
	}
}
