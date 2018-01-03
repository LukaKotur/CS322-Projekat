using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjekatData;
using ProjekatData.Models;

namespace ProjekatServisi
{
    public class IznajmljivanjeService : IIznajmljivanje
    {
        private DataContext _context;

        public IznajmljivanjeService(DataContext context)
        {
            _context = context;
        }

        public void Add(Iznajmljivanje novoIznajmljivanje)
        {
            _context.Add(novoIznajmljivanje);
            _context.SaveChanges();
        }

        public IEnumerable<Iznajmljivanje> GetAll()
        {
            return _context.Iznajmljivanje;
        }

        public Iznajmljivanje GetById(int id)
        {
            return GetAll().FirstOrDefault(iz => iz.Id == id);
        }

        public string GetCurrentClanName(int rezervacijaId)
        {
            var rezervacija = _context.Rezervacija
                .Include(h => h.VideoKlubAsset)
                .Include(h => h.ClanskaKarta)
                .FirstOrDefault(h => h.Id == rezervacijaId);

            var idKartice = rezervacija?.ClanskaKarta.Id;

            var clan = _context.Clanovi
                .Include(c => c.ClanskaKarta)
                .FirstOrDefault(c => c.ClanskaKarta.Id == idKartice);

            return clan?.Ime + " " + clan.Prezime;
        }

        public DateTime GetCurrentRezervacija(int id)
        {
            return _context.Rezervacija
                .Include(h => h.VideoKlubAsset)
                .Include(h => h.ClanskaKarta)
                .FirstOrDefault(h => h.Id == id).StavljenaRezervacija;
        }

        public IEnumerable<Rezervacija> GetCurrentRezervacije(int id)
        {
            return _context.Rezervacija
                .Include(h => h.VideoKlubAsset)
                .Where(h => h.VideoKlubAsset.Id == id);
        }

        public IEnumerable<IstorijaIznajmljivanja> GetIstorijaIznajmljivanja(int id)
        {
            return _context.IstorijaIznajmljivanja
                .Include(i => i.VideoKlubAsset)
                .Include(i => i.ClanskaKarta)
                .Where(i => i.VideoKlubAsset.Id == id);
        }

        public Iznajmljivanje GetLatestIznajmljivanje(int id)
        {
            return _context.Iznajmljivanje
                .Where(h => h.VideoKlubAsset.Id == id)
                .OrderByDescending(h => h.DatumPocetka)
                .FirstOrDefault();
        }

        public string GetCurrentClanIznajmljeno(int id)
        {
            var iznajmljeno = GetIznajmljeniById(id);
            if (iznajmljeno == null)
            {
                return "Nije iznajmljeno.";
            }
            var idKartice = iznajmljeno.ClanskaKarta.Id;

            var clan = _context.Clanovi
                .Include(c => c.ClanskaKarta)
                .FirstOrDefault(c => c.ClanskaKarta.Id == idKartice);
            return clan.Ime + " " + clan.Prezime;
        }

        private Iznajmljivanje GetIznajmljeniById(int id)
        {
            return _context.Iznajmljivanje
                .Include(iz => iz.VideoKlubAsset)
                .Include(iz => iz.ClanskaKarta)
                .FirstOrDefault(iz => iz.VideoKlubAsset.Id == id);
        }

        public void IznajmiItem(int assetId, int clanskaKartaId)
        {
            var now = DateTime.Now;
            if (IsIznajmljeno(assetId))
            {
                return;
            }

            var item = _context.VideoKlubAsset
                .FirstOrDefault(c => c.Id == assetId);

            _context.Update(item);

            UpdateAssetStatus(assetId, "Iznajmljen");

            var kartica = _context.ClanskaKarta.Include(k => k.SvaIznajmljivanja)
                .FirstOrDefault(k => k.Id == clanskaKartaId);

            kartica.Dug += item.Cena;
            var iznajmljivanje = new Iznajmljivanje
            {
                VideoKlubAsset = item,
                ClanskaKarta = kartica,
                DatumPocetka = now,
                DatumKraja = GetDefaultCheckoutTime(now)
            };

            _context.Add(iznajmljivanje);

            var istorijaIznajmljivanja = new IstorijaIznajmljivanja
            {
                DatumIznajmljivanja = now,
                VideoKlubAsset = item,
                ClanskaKarta = kartica
            };

            _context.Add(istorijaIznajmljivanja);

            _context.SaveChanges();
        }

        private DateTime GetDefaultCheckoutTime(DateTime now)
        {
            return now.AddDays(30);
        }

        public bool IsIznajmljeno(int id)
        {
            return _context.Iznajmljivanje
                .Where(i => i.VideoKlubAsset.Id == id)
                .Any();
        }

        public void ObeleziIzgubljeno(int id)
        {
            UpdateAssetStatus(id, "Izgubljen");
        }

        public void ObeleziNadjeno(int id)
        {
            var now = DateTime.Now;

            UpdateAssetStatus(id, "Dostupan");

            RemovePostojecaIznajmljivanja(id);

            RemoveIstorija(id, now);

            _context.SaveChanges();
        }

        private void UpdateAssetStatus(int id, string v)
        {
            var item = _context.VideoKlubAsset
                .FirstOrDefault(c => c.Id == id);

            _context.Update(item);

            item.Status = _context.Status.FirstOrDefault(status => status.Naziv == v);
        }

        private void RemoveIstorija(int id, DateTime now)
        {
            var istorija =
                _context.IstorijaIznajmljivanja.FirstOrDefault(h =>
                    h.VideoKlubAsset.Id == id && h.DatumVracanja == null);

            if (istorija != null)
            {
                _context.Update(istorija);
                istorija.DatumVracanja = now;
            }
        }

        private void RemovePostojecaIznajmljivanja(int id)
        {
            var iznajmljivanje = _context.Iznajmljivanje.FirstOrDefault(c => c.VideoKlubAsset.Id == id);

            if (iznajmljivanje != null)
            {
                _context.Remove(iznajmljivanje);
            }
        }

        public void Rezervisi(int id, int clanskaKarticaId)
        {
            var now = DateTime.Now;

            var item = _context.VideoKlubAsset
                .Include(c => c.Status)
                .FirstOrDefault(c => c.Id == id);

            var kartica = _context.ClanskaKarta.Include(k => k.SvaIznajmljivanja)
                .FirstOrDefault(k => k.Id == clanskaKarticaId);

            if (item.Status.Naziv == "Dostupan")
            {
                UpdateAssetStatus(id, "Rezervisan");
            }

            var rezervacija = new Rezervacija
            {
                StavljenaRezervacija = now,
                VideoKlubAsset = item,
                ClanskaKarta = kartica
            };

            _context.Add(rezervacija);
            _context.SaveChanges();
        }

        public void VratiItem(int id)
        {
            var now = DateTime.Now;

            RemovePostojecaIznajmljivanja(id);

            RemoveIstorija(id, now);

            var trenutneRezervacije = _context.Rezervacija
                .Include(h => h.VideoKlubAsset)
                .Include(h => h.ClanskaKarta)
                .Where(h => h.VideoKlubAsset.Id == id);

            if (trenutneRezervacije.Any())
            {
                IznajmiPrvojRezervaciji(id, trenutneRezervacije);
                return;
            }



            UpdateAssetStatus(id, "Dostupan");

            _context.SaveChanges();
        }

        private void IznajmiPrvojRezervaciji(int assetId, IQueryable<Rezervacija> trenutneRezervacije)
        {
            var prvaRezervacija = trenutneRezervacije
                .OrderBy(h => h.StavljenaRezervacija)
                .FirstOrDefault();

            var kartica = prvaRezervacija.ClanskaKarta;

            _context.Remove(prvaRezervacija);
            _context.SaveChanges();
            IznajmiItem(assetId, kartica.Id);
        }
    }
}