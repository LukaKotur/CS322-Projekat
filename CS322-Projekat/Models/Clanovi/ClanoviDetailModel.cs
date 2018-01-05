using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjekatData.Models;

namespace CS322_Projekat.Models.Clanovi
{
    public class ClanoviDetailModel
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public int ClanskaKarticaId { get; set; }
        public DateTime ClanOd { get; set; }
        public string Telefon { get; set; }
        public string ClanPoslovnice { get; set; }
        public int ClanPoslovniceId { get; set; }
        public string DatumRodjenja { get; set; }
        public decimal Dug { get; set; }
        public IEnumerable<Iznajmljivanje> IznajmljeneStvari { get; set; }
        public IEnumerable<IstorijaIznajmljivanja> IstorijaIznajmljivanja { get; set; }
        public IEnumerable<Rezervacija> Rezervacije { get; set; }

        public int LokacijaId { get; set; }
        public List<SelectListItem> SveLokacije { get; set; }
    }
}