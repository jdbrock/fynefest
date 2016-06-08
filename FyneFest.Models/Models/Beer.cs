using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FyneFest
{
    [ImplementPropertyChanged]
    public class Beer
    {
        [JsonIgnore]
		public String SearchHaystack { get { return String.Join(" ", BreweryName ?? "", BeerName ?? "", ABVAndStyle ?? ""); } }

        public String Id { get; set; }
        public String BreweryName { get; set; }
        public String BeerName { get; set; }
        public String StyleName { get; set; }
        public Decimal ABV { get; set; }

        //public String SuperStyleName { get; set; }

        //public Int32 SessionNumber { get; set; }
        //public String SessionName { get; set; }

        //public Int32? LocationNumber
        //{
        //    get
        //    {
        //        if (!String.IsNullOrWhiteSpace(BreweryName) && Locations.BeerLocationMap.ContainsKey(BreweryName))
        //            return Locations.BeerLocationMap[BreweryName];

        //        return null;
        //    }
        //}

        //public String LocationDirection
        //{
        //    get
        //    {
        //        var number = LocationNumber;

        //        if (number.HasValue && Locations.CompassDirectionMap.ContainsKey(number.Value))
        //            return Locations.CompassDirectionMap[number.Value];

        //        return null;
        //    }
        //}

        public String ABVAndStyle { get { return String.Format("{0:0.0}% {1}", ABV, StyleName); } }

        //public FyneFestSession Session { get { return (FyneFestSession)Enum.Parse(typeof(FyneFestSession), SessionName); } }

        [JsonIgnore]
        public BeerMetaData MetaData { get; set; }

        public Beer()
        {
            MetaData = new BeerMetaData();
        }

        public override string ToString()
        {
            return $"[{BreweryName}] [{BeerName}] [{ABV}%] [{StyleName}]";
        }
    }
}
