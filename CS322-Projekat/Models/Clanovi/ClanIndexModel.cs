using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS322_Projekat.Models.Clanovi
{
    public class ClanIndexModel
    {
        public IEnumerable<ClanoviDetailModel> Clanovi { get; set; }
    }
}