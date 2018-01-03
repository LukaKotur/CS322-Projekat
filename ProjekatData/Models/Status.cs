using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjekatData.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Opis { get; set; }
    }
}
