using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjekatData;
using ProjekatData.Models;

namespace ProjekatServisi
{
    public class ZaposleniService : IZaposleni
    {
        private DataContext _context;

        public ZaposleniService(DataContext context)
        {
            _context = context;
        }


        public Zaposleni Get(int id, string ime)
        {
            return GetAll().FirstOrDefault(c => c.Ime == ime && c.Id == id);
        }

        public IEnumerable<Zaposleni> GetAll()
        {
            return _context.Zaposleni;
        }
    }
}