using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LocalAddresses
{
    public class Addresses 
    {
        /// <summary>
        /// Array of the identifier name addresses.
        /// </summary>
        private static string[,] TypeAddressCityCountry = new string[12, 4]
        {
            {"Bus", "Trg Osvobodilne fronte 4","Ljubljana", "Slovenia"},
            {"Dist", "Dunajska cesta 109","Ljubljana", "Slovenia"},
            {"Dist", "Celovska cesta 67","Ljubljana", "Slovenia"},
            {"Market", "Ameriška Ulica 8","Ljubljana", "Slovenia"},
            {"Park", "Krekov trg 3","Ljubljana", "Slovenia"},
            {"Dist", "Vilharjeva cesta 103","Ljubljana", "Slovenia"},
            {"Coffee", "Hladnikova cesta 12","Ljubljana", "Slovenia"},
            {"School", "Topniska cesta 4","Ljubljana", "Slovenia"},
            {"Dist", "Linhartova cesta 9","Ljubljana", "Slovenia"},
            {"Dist", "Litostrojska cesta 98","Ljubljana", "Slovenia"},
            {"School", "Vodnikova cesta 17","Ljubljana", "Slovenia"},
            {"Dist", "Kajuhova ulica 4","Ljubljana", "Slovenia"},
        };

        /// <summary>
        /// Gets the Array of identifier name addresses.
        /// </summary>
        /// <returns>The identifier name addresses.</returns>
        public static string[,] getTypeAddressCityCountries()
        {
            return TypeAddressCityCountry;
        }

        
        public static Sprite getIcon(string type)
        {
            return Resources.Load("Main/UI/AddressTypes/" + type.ToString(), typeof(Sprite)) as Sprite;
        }
    }
}


