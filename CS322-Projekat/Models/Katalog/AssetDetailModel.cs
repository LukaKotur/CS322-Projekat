using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjekatData.Models;

namespace CS322_Projekat.Models.Katalog
{
    public class AssetDetailModel
    {
        public int AssetId { get; set; }
        public string Naziv { get; set; }
        public string Producent { get; set; }
        public DateTime DatumIzlaska { get; set; }
        public string GlavniGlumci { get; set; }
        public string Status { get; set; }
        public string ImgUrl { get; set; }
        public string ImeClana { get; set; }
        public string TrenutnaLokacija { get; set; }
        public string Cena { get; set; }
        public string DatumVracanja { get; set; }
        public int BrojKopija { get; set; }
        public Iznajmljivanje LatestIznajmljivanje { get; set; }
        public IEnumerable<IstorijaIznajmljivanja> IstorijaIznajmljivanja { get; set; }
        public IEnumerable<AssetRezervacijaModel> TrenutneRezervacije { get; set; }
    }

    public class AssetRezervacijaModel
    {
        public string ImeClana { get; set; }
        public string Rezervisano { get; set; }
    }
}