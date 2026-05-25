using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Generator
{
    class Program
    {
        public static SteamApiDefinition Definitions;
        static readonly JsonSerializerOptions JsonOptions = new() {
            PropertyNameCaseInsensitive = true,
        };

        static void Main( string[] args )
        {
            var content = System.IO.File.ReadAllText( "steam_sdk/steam_api.json" );
            var def = JsonSerializer.Deserialize<SteamApiDefinition>( content, JsonOptions )
                ?? throw new InvalidOperationException( "Failed to deserialize steam_api.json" );

            Definitions = def;

            var generator = new CodeWriter( def );

            generator.ToFolder( "../Facepunch.Steamworks/Generated/" );
        }
    }
}
