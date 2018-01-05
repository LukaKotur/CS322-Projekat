using System;
using System.Collections.Generic;
using System.Text;
using ProjekatData.Models;

namespace ProjekatData
{
    public interface IClan
    {
        Clan Get(int id);
        IEnumerable<Clan> GetAll();
        void Add(Clan noviClan);
        void Edit(int id);
        void Remove(int id);

        void PlatiDug(int id, decimal dug);

        void AddClanskaKarta(ClanskaKarta karta);

        VideoKlubOgranak GetPoslovnica(int id);

        IEnumerable<IstorijaIznajmljivanja> GetIstorijaIznajmljivanja(int clanId);
        IEnumerable<Rezervacija> GetRezervacije(int clanId);
        IEnumerable<Iznajmljivanje> GetIznajmljivanja(int clanId);
    }
}