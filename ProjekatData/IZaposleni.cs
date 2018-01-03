using System;
using System.Collections.Generic;
using System.Text;
using ProjekatData.Models;

namespace ProjekatData
{
    public interface IZaposleni
    {
        Zaposleni Get(int id, string ime);
        IEnumerable<Zaposleni> GetAll();
    }
}