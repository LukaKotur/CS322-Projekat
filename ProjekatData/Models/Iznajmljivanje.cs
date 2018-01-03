using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjekatData.Models
{
    public class Iznajmljivanje
    {
        public int Id { get; set; }

        [Required]
        public VideoKlubAsset VideoKlubAsset { get; set; }

        public ClanskaKarta ClanskaKarta { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumKraja { get; set; }
    }
}