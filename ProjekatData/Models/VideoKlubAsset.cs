using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjekatData.Models
{
    public abstract class VideoKlubAsset
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public DateTime DatumIzlaska{ get; set; }

        [Required]
        public decimal Cena { get; set; }

        [Required]
        public Status Status { get; set; }

        public string ImgUrl { get; set; }

        public int BrojKopija { get; set; }

        public virtual VideoKlubOgranak Lokacija { get; set; }
    }
}