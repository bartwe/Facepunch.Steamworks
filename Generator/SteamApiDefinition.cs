using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Generator
{
    public class SteamApiDefinition
    {
        public class Interface
        {
            [JsonPropertyName("classname")]
            public string Name { get; set; }

            [JsonPropertyName("version_string")]
            public string VersionString { get; set; }

            public class Method
            {
                public string Desc { get; set; }
                public string ReturnType { get; set; }
                public string CallResult { get; set; }

                public class Param
                {
                    public string ParamType { get; set; }
                    public string ParamName { get; set; }
                }

                public Param[] Params { get; set; }
                [JsonPropertyName("methodname")]
                public string Name { get; set; }
                [JsonPropertyName("methodname_flat")]
                public string FlatName { get; set; }

            }

            public Method[] Methods { get; set; }


            public class Accessor
            {
                public string Kind { get; set; }
                public string Name { get; set; }
                public string Name_Flat { get; set; }
            }

            public Accessor[] Accessors { get; set; }

        }

        public Interface[] Interfaces { get; set; }


        public class EnumDef
        {
            public class EnumValue
            {
                [JsonPropertyName("name")]
                public string Name { get; set; }
                [JsonPropertyName("value")]
                public string Value { get; set; }
            }

            [JsonPropertyName("enumname")]
            public string Name { get; set; }
            [JsonPropertyName("values")]
            public EnumValue[] Values { get; set; }
        }

        public EnumDef[] enums { get; set; }


        public class TypeDef
        {
            [JsonPropertyName("typedef")]
            public string Name { get; set; }
            [JsonPropertyName("type")]
            public string Type { get; set; }
        }

        public List<TypeDef> typedefs { get; set; }

        public class StructDef
        {
            public class StructFields
            {
                [JsonPropertyName("fieldname")]
                public string Name { get; set; }
                [JsonPropertyName("fieldtype")]
                public string Type { get; set; }
            }

            [JsonPropertyName("struct")]
            public string Name { get; set; }
            [JsonPropertyName("fields")]
            public StructFields[] Fields { get; set; }
            public Interface.Method[] Methods { get; set; }

            public bool IsPack4OnWindows
            {
                get
                {
                    // 4/8 packing is irrevant to these classes
                    if ( Name.Contains( "MatchMakingKeyValuePair_t" ) ) return true;

                    if ( Fields.Skip( 1 ).Any( x => x.Type.Contains( "CSteamID" ) ) )
                        return true;

                    if ( Fields.Skip( 1 ).Any( x => x.Type.Contains( "CGameID" ) ) )
                        return true;

                    return false;
                }
            }

            public EnumDef[] Enums { get; set; }

        }

        public List<StructDef> structs { get; set; }

        public class CallbackStructDef : StructDef
        {
            [JsonPropertyName("callback_id")]
            public int CallbackId { get; set; }
        }

        public List<CallbackStructDef> callback_structs { get; set; }

        public class Const
        {
            [JsonPropertyName("consttype")]
            public string Type { get; set; }

            [JsonPropertyName("constname")]
            public string Name { get; set; }


            [JsonPropertyName("constval")]
            public string Val { get; set; }
        }

        public List<Const> Consts { get; set; }
    }


}
