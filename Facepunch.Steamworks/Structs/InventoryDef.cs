using System;
using System.Collections.Generic;
using System.Linq;
using Steamworks.Data;

namespace Steamworks {
    public sealed class InventoryDef : IEquatable<InventoryDef> {
        internal InventoryDefId _id;
        internal Dictionary<string, string> _properties;

        InventoryRecipe[] _recContaining;

        public InventoryDef(InventoryDefId defId) {
            _id = defId;
        }

        public int Id {
            get { return _id.Value; }
        }

        /// <summary>
        ///     Shortcut to call GetProperty( "name" )
        /// </summary>
        public string Name {
            get { return GetProperty("name"); }
        }

        /// <summary>
        ///     Shortcut to call GetProperty( "description" )
        /// </summary>
        public string Description {
            get { return GetProperty("description"); }
        }

        /// <summary>
        ///     Shortcut to call GetProperty( "icon_url" )
        /// </summary>
        public string IconUrl {
            get { return GetProperty("icon_url"); }
        }

        /// <summary>
        ///     Shortcut to call GetProperty( "icon_url_large" )
        /// </summary>
        public string IconUrlLarge {
            get { return GetProperty("icon_url_large"); }
        }

        /// <summary>
        ///     Shortcut to call GetProperty( "price_category" )
        /// </summary>
        public string PriceCategory {
            get { return GetProperty("price_category"); }
        }

        /// <summary>
        ///     Shortcut to call GetProperty( "type" )
        /// </summary>
        public string Type {
            get { return GetProperty("type"); }
        }

        /// <summary>
        ///     Returns true if this is an item that generates an item, rather
        ///     than something that is actual an item
        /// </summary>
        public bool IsGenerator {
            get { return Type == "generator"; }
        }

        /// <summary>
        ///     Shortcut to call GetProperty( "exchange" )
        /// </summary>
        public string ExchangeSchema {
            get { return GetProperty("exchange"); }
        }

        /// <summary>
        ///     Shortcut to call GetBoolProperty( "marketable" )
        /// </summary>
        public bool Marketable {
            get { return GetBoolProperty("marketable"); }
        }

        /// <summary>
        ///     Shortcut to call GetBoolProperty( "tradable" )
        /// </summary>
        public bool Tradable {
            get { return GetBoolProperty("tradable"); }
        }

        /// <summary>
        ///     Gets the property timestamp
        /// </summary>
        public DateTime Created {
            get { return GetProperty<DateTime>("timestamp"); }
        }

        /// <summary>
        ///     Gets the property modified
        /// </summary>
        public DateTime Modified {
            get { return GetProperty<DateTime>("modified"); }
        }

        /// <summary>
        ///     Gets a list of all properties on this item
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Properties {
            get {
                var list = GetProperty(null);
                var keys = list.Split(',');

                foreach (var key in keys) {
                    yield return new(key, GetProperty(key));
                }
            }
        }

        /// <summary>
        ///     Returns the price of this item in the local currency (SteamInventory.Currency)
        /// </summary>
        public int LocalPrice {
            get {
                ulong curprice = 0;
                ulong baseprice = 0;

                if (!SteamInventory.Internal.GetItemPrice(Id, ref curprice, ref baseprice))
                    return 0;

                return (int)curprice;
            }
        }

        public string LocalPriceFormatted {
            get { return Utility.FormatPrice(SteamInventory.Currency, LocalPrice / 100.0); }
        }

        /// <summary>
        ///     If the price has been discounted, LocalPrice will differ from LocalBasePrice
        ///     (assumed, this isn't documented)
        /// </summary>
        public int LocalBasePrice {
            get {
                ulong curprice = 0;
                ulong baseprice = 0;

                if (!SteamInventory.Internal.GetItemPrice(Id, ref curprice, ref baseprice))
                    return 0;

                return (int)baseprice;
            }
        }

        public string LocalBasePriceFormatted {
            get { return Utility.FormatPrice(SteamInventory.Currency, LocalPrice / 100.0); }
        }

        public bool Equals(InventoryDef p) {
            if (p == null)
                return false;
            return p.Id == Id;
        }

        /// <summary>
        ///     Get a list of exchanges that are available to make this item
        /// </summary>
        public InventoryRecipe[] GetRecipes() {
            if (string.IsNullOrEmpty(ExchangeSchema))
                return null;

            var parts = ExchangeSchema.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            return parts.Select(x => InventoryRecipe.FromString(x, this)).ToArray();
        }

        /// <summary>
        ///     Get a specific property by name
        /// </summary>
        public string GetProperty(string name) {
            if ((_properties != null) && _properties.TryGetValue(name, out string val))
                return val;

            uint _ = Helpers.MemoryBufferSize;

            if (!SteamInventory.Internal.GetItemDefinitionProperty(Id, name, out var vl, ref _))
                return null;

            if (name == null) //return keys string
                return vl;

            if (_properties == null)
                _properties = new();

            _properties[name] = vl;

            return vl;
        }

        /// <summary>
        ///     Read a raw property from the definition schema
        /// </summary>
        public bool GetBoolProperty(string name) {
            string val = GetProperty(name);

            if (val.Length == 0)
                return false;
            if ((val[0] == '0') || (val[0] == 'F') || (val[0] == 'f'))
                return false;

            return true;
        }

        /// <summary>
        ///     Read a raw property from the definition schema
        /// </summary>
        public T GetProperty<T>(string name) {
            string val = GetProperty(name);

            if (string.IsNullOrEmpty(val))
                return default;

            try {
                return (T)Convert.ChangeType(val, typeof(T));
            }
            catch (Exception) {
                return default;
            }
        }

        /// <summary>
        ///     Return a list of recepies that contain this item
        /// </summary>
        public InventoryRecipe[] GetRecipesContainingThis() {
            if (_recContaining != null)
                return _recContaining;

            var allRec = SteamInventory.Definitions
                .Select(x => x.GetRecipes())
                .Where(x => x != null)
                .SelectMany(x => x);

            _recContaining = allRec.Where(x => x.ContainsIngredient(this)).ToArray();
            return _recContaining;
        }

        public static bool operator ==(InventoryDef a, InventoryDef b) {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);

            return a.Equals(b);
        }

        public static bool operator !=(InventoryDef a, InventoryDef b) {
            return !(a == b);
        }

        public override bool Equals(object p) {
            return Equals((InventoryDef)p);
        }

        public override int GetHashCode() {
            return Id.GetHashCode();
        }
    }
}
