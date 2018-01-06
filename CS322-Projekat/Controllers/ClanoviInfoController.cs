using System;
using System.Collections.Generic;
using System.Linq;
using CS322_Projekat.Models.Clanovi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjekatData;
using ProjekatData.Models;

namespace CS322_Projekat.Controllers
{
    [Authorize]
    public class ClanoviInfoController : Controller
    {
        #region Fields/Constructor

        private IClan _clan;
        private DataContext _context;

        public ClanoviInfoController(IClan clan, DataContext context)
        {
            _clan = clan;
            _context = context;
        }

        #endregion

        #region Index/Detail

        public IActionResult Index()
        {
            var sviClanovi = _clan.GetAll();

            var clanoviModels = sviClanovi
                .Select(c => new ClanoviDetailModel
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
                Rezervacije = _clan.GetRezervacije(id),
                Telefon = clan.Telefon
            };

            return View(model);
        }

        #endregion

        #region Uplati dug

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

        #endregion

        #region Dodaj novog clana

        public IActionResult DodajClana()
        {
            ClanoviDetailModel model = new ClanoviDetailModel
            {
                SveLokacije = _context.VideoKlubOgranak.Select(a => new SelectListItem()
                {
                    Value = a.Id.ToString(),
                    Text = a.Naziv
                }).ToList(),
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult Dodaj(string ime, string prezime, string adresa, string telefon, string datumRodjenja,
            int lokacijaId)
        {
            DateTime datumRodjenjaClana = DateTime.ParseExact(datumRodjenja, "MM/dd/yyyy", null);


            Clan noviClan = new Clan();
            noviClan.Ime = ime;
            noviClan.Prezime = prezime;
            noviClan.Adresa = adresa;
            noviClan.Telefon = telefon;
            noviClan.DatumRodjenja = datumRodjenjaClana;
            noviClan.ClanOgranka = _clan.GetPoslovnica(lokacijaId);
            ClanskaKarta novaKarta = new ClanskaKarta();
            novaKarta.Dug = 0;
            novaKarta.VremePravljenja = DateTime.Now;

            _clan.AddClanskaKarta(novaKarta);
            noviClan.ClanskaKarta = novaKarta;

            _clan.Add(noviClan);

            return RedirectToAction("Index");
        }

        #endregion

        #region Edit/Remove

        public IActionResult Edit(int id)
        {
            var clan = _clan.Get(id);
            ClanoviDetailModel model = new ClanoviDetailModel
            {
                Id = clan.Id,
                Ime = clan.Ime,
                Prezime = clan.Prezime,
                Adresa = clan.Adresa,
                Telefon = clan.Telefon,
                DatumRodjenja = clan.DatumRodjenja.ToString("d"),
                LokacijaId = clan.ClanOgranka.Id,
                SveLokacije = _context.VideoKlubOgranak.Select(a => new SelectListItem()
                {
                    Value = a.Id.ToString(),
                    Text = a.Naziv
                }).ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditPost(int id, string ime, string prezime, string adresa, string telefon,
            string datumRodjenja,
            int lokacijaId)
        {
            Clan clan = _clan.Get(id);

            clan.Ime = ime;
            clan.Prezime = prezime;
            clan.Adresa = adresa;
            clan.Telefon = telefon;
            clan.DatumRodjenja = DateTime.ParseExact(datumRodjenja.Substring(0, 10), "dd/MM/yyyy", null);
            clan.ClanOgranka = _clan.GetPoslovnica(lokacijaId);

            _clan.Edit(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int id)
        {
            _clan.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}