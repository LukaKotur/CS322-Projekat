using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatData.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public virtual VideoKlubAsset VideoKlubAsset { get; set; }
        public virtual ClanskaKarta ClanskaKarta { get; set; }
        public DateTime StavljenaRezervacija { get; set; }
    }
}