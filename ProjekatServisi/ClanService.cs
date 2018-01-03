﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjekatData;
using ProjekatData.Models;

namespace ProjekatServisi
{
    public class ClanService : IClan
    {
        private DataContext _context;

        public ClanService(DataContext context)
        {
            _context = context;
        }

        public Clan Get(int id)
        {
            return GetAll()
                .FirstOrDefault(clan => clan.Id == id);
        }

        public IEnumerable<Clan> GetAll()
        {
            return _context.Clanovi
                .Include(clan => clan.ClanskaKarta)
                .Include(clan => clan.ClanOgranka);
        }

        public void Add(Clan noviClan)
        {
            _context.Add(noviClan);
            _context.SaveChanges();
        }

        public void AddClanskaKarta(ClanskaKarta karta)
        {
            _context.Add(karta);
            _context.SaveChanges();
        }

        public VideoKlubOgranak GetPoslovnica(int id)
        {
            return _context.VideoKlubOgranak
                .FirstOrDefault(vo => vo.Id == id);
        }

        public void PlatiDug(int karticaId, decimal dug)
        {
            var kartica = _context.ClanskaKarta.FirstOrDefault(c => c.Id == karticaId);

            if (kartica.Dug >= dug)
            {
                kartica.Dug -= dug;
            }

            _context.Update(kartica);

            _context.SaveChanges();
        }

        public IEnumerable<IstorijaIznajmljivanja> GetIstorijaIznajmljivanja(int clanId)
        {
            var karticaId = Get(clanId)
                .ClanskaKarta.Id;

            return _context.IstorijaIznajmljivanja
                .Include(istorija => istorija.ClanskaKarta)
                .Include(istorija => istorija.VideoKlubAsset)
                .Where(istorija => istorija.ClanskaKarta.Id == karticaId)
                .OrderByDescending(istorija => istorija.DatumIznajmljivanja);
        }

        public IEnumerable<Rezervacija> GetRezervacije(int clanId)
        {
            var karticaId = Get(clanId)
                .ClanskaKarta.Id;

            return _context.Rezervacija
                .Include(c => c.ClanskaKarta)
                .Include(c => c.VideoKlubAsset)
                .Where(c => c.ClanskaKarta.Id == karticaId)
                .OrderByDescending(c => c.StavljenaRezervacija);
        }

        public IEnumerable<Iznajmljivanje> GetIznajmljivanja(int clanId)
        {
            var karticaId = Get(clanId)
                .ClanskaKarta.Id;

            return _context.Iznajmljivanje
                .Include(rez => rez.ClanskaKarta)
                .Include(rez => rez.VideoKlubAsset)
                .Where(rez => rez.ClanskaKarta.Id == karticaId);
        }
    }
}