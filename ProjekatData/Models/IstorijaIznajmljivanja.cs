using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjekatData.Models
{
    public class IstorijaIznajmljivanja
    {
        public int Id { get; set; }

        [Required]
        public VideoKlubAsset VideoKlubAsset { get; set; }

        [Required]
        public ClanskaKarta ClanskaKarta { get; set; }

        [Required]
        public DateTime DatumIznajmljivanja { get; set; }

        public DateTime? DatumVracanja { get; set; }
    }
}