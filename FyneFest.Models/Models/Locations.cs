using System;
using System.Collections.Generic;
using System.Text;

namespace FyneFest
{
    public class Locations
    {
        public static readonly Dictionary<String, Int32> BeerLocationMap = new Dictionary<String, Int32>()
        {
            { "18th Street Brewery", 6 },
            { "3 Floyd's Brewing Company", 3 },
            { "7venth Sun Brewery", 18 },
            { "8 Wired Brewing", 30 },
            { "AleSmith Brewing Company", 1 },
            { "Alpha State", 37 },
            { "Amager Bryghus", 51 },
            { "Arizona Wilderness Brewing Company", 28 },
            { "B. Nektar Meadery", 41 },
            { "Bagby Beer Company", 36 },
            { "Baird Brewing Company", 25 },
            { "Beavertown Brewery", 10 },
            { "Bell's Brewery, Inc.", 11 },
            { "Boneyard Beer", 53 },
            { "Boxing Cat Brewery", 17 },
            { "Brekeriet", 50 },
            { "BrewDog", 15 },
            { "Buxton Brewery", 35 },
            { "Cellarmaker Brewing Company", 22 },
            { "Cigar City Brewing", 45 },
            { "Cigar City Cider & Mead", 44 },
            { "Crooked Stave Artisan Beer Project", 27 },
            { "Cycle Brewing", 16 },
            { "Edge Brewing Barcelona", 52 },
            { "Firestone Walker Brewing Company", 14 },
            { "Gigantic Brewing Company", 29 },
            { "Green Flash Brewing Company", 39 },
            { "Jackie O's Pub & Brewery", 26 },
            { "Jester King Brewery", 33 },
            { "Lervig Aktiebryggeri", 49 },
            { "LoverBeer", 46 },
            { "MAD Beer", 42 },
            { "Magic Rock Brewing Company", 23 },
            { "Mikkeller", 2 },
            { "Mikropolis", 5 },
            { "Omnipollo", 47 },
            { "Side Project Brewing", 9 },
            { "Siren Craft Brew", 38 },
            { "Stillwater Artisanal", 48 },
            { "Superstition Meadery", 43 },
            { "Surly Brewing Company", 7 },
            { "The Kernel Brewery", 32 },
            { "Tired Hands Brewing Company", 19 },
            { "To Øl", 4 },
            { "Virtue Cider", 40 },
            { "WarPigs", 8 },
            { "Way Beer", 34 },
            { "Westbrook Brewing", 24 }
        };

        public static readonly Dictionary<Int32, String> CompassDirectionMap = new Dictionary<Int32, String>
        {
            { 1, "Center East" },
            { 2, "Center East" },
            { 3, "Center East" },
            { 4, "Center East" },
            { 5, "Center East" },
            { 6, "Center East" },
            { 7, "Center East" },
            { 8, "Center East" },
            { 9, "Center East" },
            { 10, "Center East" },
            { 11, "Center East" },
            { 12, "Center East" },

            { 31, "Center West" },
            { 32, "Center West" },
            { 33, "Center West" },
            { 34, "Center West" },
            { 35, "Center West" },
            { 36, "Center West" },
            { 37, "Center West" },
            { 38, "Center West" },
            { 39, "Center West" },
            { 40, "Center West" },
            { 41, "Center West" },
            { 42, "Center West" },

            { 50, "North East" },
            { 51, "North East" },
            { 52, "North East" },
            { 53, "North East" },
            { 54, "North East" },

            { 55, "Far East" },
   
            { 43, "North West" },
            { 44, "North West" },
            { 45, "North West" },
            { 46, "North West" },
            { 47, "North West" },
            { 48, "North West" },
            { 49, "North West" },
                        
            { 21, "South West" },
            { 22, "South West" },
            { 23, "South West" },
            { 24, "South West" },
            { 25, "South West" },
            { 26, "South West" },
            { 27, "South West" },
            { 28, "South West" },
            { 29, "South West" },
            { 30, "South West" },

            { 13, "South East" },
            { 14, "South East" },
            { 15, "South East" },
            { 16, "South East" },
            { 17, "South East" },
            { 18, "South East" },
            { 19, "South East" },
            { 20, "South East" }
        };

        public static readonly Dictionary<Int32, String> AllStandsLocations = new Dictionary<Int32, String>
        {
            { 1, "AleSmith Brewing Company" },
            { 2, "Mikkeller" },
            { 3, "3 Floyd's Brewing Company" },
            { 4, "To Øl" },
            { 5, "Mikropolis" },
            { 6, "18th Street Brewery" },
            { 7, "Surly Brewing Company" },
            { 8, "WarPigs" },
            { 9, "Side Project Brewing" },
            { 10, "Beavertown Brewery" },
            { 11, "Bell's Brewery, Inc." },

            { 12, "Mostra Coffee" },
            { 13, "Nails & Ales" },

            { 14, "Firestone Walker Brewing Company" },
            { 15, "BrewDog" },
            { 16, "Cycle Brewing" },
            { 17, "Boxing Cat Brewery" },
            { 18, "7venth Sun Brewery" },
            { 19, "Tired Hands Brewing Company" },

            { 20, "Arla Unika" },
            { 21, "Frederiksdal" },


            { 22, "Cellarmaker Brewing Company" },
            { 23, "Magic Rock Brewing Company" },
            { 24, "Westbrook Brewing" },
            { 25, "Baird Brewing Company" },
            { 26, "Jackie O's Pub & Brewery" },
            { 27, "Crooked Stave Artisan Beer Project" },
            { 28, "Arizona Wilderness Brewing Company" },
            { 29, "Gigantic Brewing Company" },
            { 30, "8 Wired Brewing" },

            { 31, "John's Hotdog Deli" },

            { 32, "The Kernel Brewery" },
            { 33, "Jester King Brewery" },
            { 34, "Way Beer" },
            { 35, "Buxton Brewery" },
            { 36, "Bagby Beer Company" },
            { 37, "Alpha State" },
            { 38, "Siren Craft Brew" },
            { 39, "Green Flash Brewing Company" },
            { 40, "Virtue Cider" },
            { 41, "B. Nektar Meadery" },
            { 42, "MAD Beer" },
            { 43, "Superstition Meadery" },
            { 44, "Cigar City Cider & Mead" },
            { 45, "Cigar City Brewing" },
            { 46, "LoverBeer" },
            { 47, "Omnipollo" },
            { 48, "Stillwater Artisanal" },
            { 49, "Lervig Aktiebryggeri" },
            { 50, "Brekeriet" },
            { 51, "Amager Bryghus" },
            { 52, "Edge Brewing Barcelona" },
            { 53, "Boneyard Beer" },

            { 54, "Crooked Moon Tattoo" },
            { 55, "Koppi / Coffee Collective" }
        };
    }
}
