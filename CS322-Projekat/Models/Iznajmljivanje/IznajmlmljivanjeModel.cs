using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS322_Projekat.Models.IznajmljivanjeModels
{
    public class IznajmljivanjeModel
    {
        public string ClanskaKartaId { get; set; }
        public string Naziv { get; set; }
        public int AssetId { get; set; }
        public string ImgUrl { get; set; }
        public int RezervacijeCount { get; set; }
        public bool isIznajmljeno { get; set; }
    }
}