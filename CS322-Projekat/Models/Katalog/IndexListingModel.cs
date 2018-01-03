using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS322_Projekat.Models.Katalog
{
    public class IndexListingModel
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string Naziv { get; set; }
        public string GlavniGlumci { get; set; }
        public int BrojKopija { get; set; }
        public string Producent { get; set; }
    }
}