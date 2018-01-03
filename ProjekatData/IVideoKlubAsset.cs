using System;
using System.Collections.Generic;
using System.Text;
using ProjekatData.Models;

namespace ProjekatData
{
    public interface IVideoKlubAsset
    {
        IEnumerable<VideoKlubAsset> GetAll();

        VideoKlubAsset GetById(int id);
        void Add(VideoKlubAsset novi);
        string GetGlavniGlumci(int id);
        string GetNaziv(int id);
        string GetProducent(int id);

        VideoKlubOgranak GetCurrentOgranak(int id);
    }
}