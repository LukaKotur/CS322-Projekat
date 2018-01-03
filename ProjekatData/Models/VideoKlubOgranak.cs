using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjekatData.Models
{
    public class VideoKlubOgranak
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Limit za naziv ogranka je 30 karaktera")]
        public string Naziv { get; set; }

        [Required]
        public string Adresa { get; set; }

        [Required]
        public string Telefon { get; set; }

        public string Opis { get; set; }
        public DateTime VremeKadaJeOtvoreno { get; set; }

        public virtual IEnumerable<Clan> Clanovi { get; set; }
        public virtual IEnumerable<VideoKlubAsset> VideoKlubAssets { get; set; }

        public string ImgUrl { get; set; }
    }
}