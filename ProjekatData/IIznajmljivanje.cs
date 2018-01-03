using System;
using System.Collections.Generic;
using System.Text;
using ProjekatData.Models;

namespace ProjekatData
{
    public interface IIznajmljivanje
    {
        IEnumerable<Iznajmljivanje> GetAll();
        Iznajmljivanje GetById(int id);

        void Add(Iznajmljivanje novoIznajmljivanje);
        void IznajmiItem(int assetId, int clanskaKartaId);
        void VratiItem(int assetId);
        IEnumerable<IstorijaIznajmljivanja> GetIstorijaIznajmljivanja(int id);
        Iznajmljivanje GetLatestIznajmljivanje(int id);
        string GetCurrentClanIznajmljeno(int id);

        void Rezervisi(int assetId, int clanskaKarticaId);
        string GetCurrentClanName(int id);
        DateTime GetCurrentRezervacija(int id);
        IEnumerable<Rezervacija> GetCurrentRezervacije(int id);

        void ObeleziIzgubljeno(int id);
        void ObeleziNadjeno(int id);
        bool IsIznajmljeno(int id);
    }
}