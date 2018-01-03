using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatData.Models
{
    public class Clan
    {
        #region Variables

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Telefon { get; set; }

        #endregion

        public virtual ClanskaKarta ClanskaKarta { get; set; }
        public virtual VideoKlubOgranak ClanOgranka { get; set; }
    }
}