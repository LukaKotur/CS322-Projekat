using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS322_Projekat.Models.Katalog
{
    public class AssetIndexModel
    {
        public IEnumerable<IndexListingModel> Assets { get; set; }
    }
}