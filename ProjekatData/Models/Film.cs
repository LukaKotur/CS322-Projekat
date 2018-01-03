using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjekatData.Models
{
    public class Film : VideoKlubAsset
    {

        [Required]
        public string GlavniGlumci { get; set; }

        [Required]
        public string Producent { get; set; }
    }
}