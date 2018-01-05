using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjekatData.Models;

namespace CS322_Projekat.Models.Katalog
{
    public class KatalogAddModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public DateTime DatumIzlaska { get; set; }

        public decimal Cena { get; set; }
        public Status Status { get; set; }

        public string ImgUrl { get; set; }

        public int BrojKopija { get; set; }

        public VideoKlubOgranak Lokacija { get; set; }

        public int LokacijaId { get; set; }
        public List<SelectListItem> SveLokacije { get; set; }

        public string GlavniGlumci { get; set; }
        public string Producent { get; set; }
    }
}