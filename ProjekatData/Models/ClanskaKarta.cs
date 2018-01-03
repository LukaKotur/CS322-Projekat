using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatData.Models
{
    public class ClanskaKarta
    {
        public int Id { get; set; }
        public decimal Dug { get; set; }
        public DateTime VremePravljenja { get; set; }
        public virtual IEnumerable<Iznajmljivanje> SvaIznajmljivanja { get; set; }
    }
}