using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjekatData.Models
{
    public class RadnoVreme
    {
        public int Id { get; set; }
        public VideoKlubOgranak Ogranak { get; set; }

        [Range(0, 6)]
        public int DanUNedelji { get; set; }

        [Range(0, 23)]
        public int VremeKadaJeOtvoreno { get; set; }

        [Range(0, 6)]
        public int VremeKadaJeZatvoreno { get; set; }
    }
}
