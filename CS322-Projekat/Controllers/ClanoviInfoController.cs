using System;
using System.Collections.Generic;
using System.Linq;
using CS322_Projekat.Models.Clanovi;
using Microsoft.AspNetCore.Mvc;
using ProjekatData;
using ProjekatData.Models;

namespace CS322_Projekat.Controllers
{
    public class ClanoviInfoController : Controller
    {
        private IClan _clan;

        public ClanoviInfoController(IClan clan)
        {
            _clan = clan;
        }

        public IActionResult Index()
        {
            var sviClanovi = _clan.GetAll();

            var clanoviModels = sviClanovi.Select(c => new ClanoviDetailModel
            {
                Id = c.Id,
                Ime = c.Ime,
                Prezime = c.Prezime,
                Adresa = c.Adresa,
                ClanskaKarticaId = c.ClanskaKarta.Id,
                Dug = c.ClanskaKarta.Dug,
                ClanPoslovnice = c.ClanOgranka.Naziv
            }).ToList();

            var model = new ClanIndexModel()
            {
                Clanovi = clanoviModels
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var clan = _clan.Get(id);

            var model = new ClanoviDetailModel
            {
                Prezime = clan.Prezime,
                Ime = clan.Ime,
                Adresa = clan.Adresa,
                ClanPoslovnice = clan.ClanOgranka.Naziv,
                ClanOd = clan.ClanskaKarta.VremePravljenja,
                Dug = clan.ClanskaKarta.Dug,
                ClanskaKarticaId = clan.ClanskaKarta.Id,
                IznajmljeneStvari = _clan.GetIznajmljivanja(id).ToList() ?? new List<Iznajmljivanje>(),
                IstorijaIznajmljivanja = _clan.GetIstorijaIznajmljivanja(id),
                Rezervacije = _clan.GetRezervacije(id)
            };

            return View(model);
        }

        public IActionResult PlatiDug(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult UplatiDug(int id, int dug)
        {
            var karticaId = _clan.Get(id).ClanskaKarta.Id;
            _clan.PlatiDug(karticaId, dug);

            return RedirectToAction("Detail", new {id = id});
        }

        public IActionResult DodajClana()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Dodaj(string ime, string prezime, string adresa, string telefon, string datumRodjenja, int clanPoslovniceId)
        {
            DateTime datumRodjenjaClana = DateTime.ParseExact(datumRodjenja, "MM/dd/yyyy",null);

            
            Clan noviClan = new Clan();
            noviClan.Ime = ime;
            noviClan.Prezime = prezime;
            noviClan.Adresa = adresa;
            noviClan.Telefon = telefon;
            noviClan.DatumRodjenja = datumRodjenjaClana;
            noviClan.ClanOgranka = _clan.GetPoslovnica(clanPoslovniceId);
            ClanskaKarta novaKarta = new ClanskaKarta();
            novaKarta.Dug = 0;
            novaKarta.VremePravljenja = DateTime.Now;

            _clan.AddClanskaKarta(novaKarta);
            noviClan.ClanskaKarta = novaKarta;

            _clan.Add(noviClan);

            return RedirectToAction("Index");
        }
    }
}