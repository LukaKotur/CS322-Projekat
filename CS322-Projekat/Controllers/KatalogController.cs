using System.Linq;
using CS322_Projekat.Models.IznajmljivanjeModels;
using CS322_Projekat.Models.Katalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekatData;

namespace CS322_Projekat.Controllers
{
    [Authorize]
    public class KatalogController : Controller
    {
        #region Fields/Constructor

        private IVideoKlubAsset _assets;
        private IIznajmljivanje _iznajmljivanje;

        public KatalogController(IVideoKlubAsset assets, IIznajmljivanje iznajmljivanje)
        {
            _assets = assets;
            _iznajmljivanje = iznajmljivanje;
        }

        #endregion

        #region Index/Detail

        public IActionResult Index()
        {
            var assetModels = _assets.GetAll();


            var listingRes = assetModels
                .Select(res => new IndexListingModel
                {
                    Id = res.Id,
                    ImgUrl = res.ImgUrl,
                    Naziv = res.Naziv,
                    Producent = _assets.GetProducent(res.Id),
                    GlavniGlumci = _assets.GetGlavniGlumci(res.Id)
                });

            var model = new AssetIndexModel()
            {
                Assets = listingRes
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var asset = _assets.GetById(id);

            var trenutneRezervacije = _iznajmljivanje.GetCurrentRezervacije(id)
                .Select(a => new AssetRezervacijaModel
                {
                    Rezervisano = _iznajmljivanje.GetCurrentRezervacija(a.Id).ToString("d"),
                    ImeClana = _iznajmljivanje.GetCurrentClanName(a.Id)
                });


            var model = new AssetDetailModel()
            {
                AssetId = id,
                Naziv = asset.Naziv,
                GlavniGlumci = _assets.GetGlavniGlumci(id),
                TrenutnaLokacija = _assets.GetCurrentOgranak(id).Naziv,
                DatumIzlaska = asset.DatumIzlaska,
                ImgUrl = asset.ImgUrl,
                Status = asset.Status.Naziv,
                Cena = asset.Cena.ToString(),
                Producent = _assets.GetProducent(id),
                IstorijaIznajmljivanja = _iznajmljivanje.GetIstorijaIznajmljivanja(id),
                LatestIznajmljivanje = _iznajmljivanje.GetLatestIznajmljivanje(id),
                ImeClana = _iznajmljivanje.GetCurrentClanIznajmljeno(id),
                TrenutneRezervacije = trenutneRezervacije,
                BrojKopija = asset.BrojKopija
            };
            return View(model);
        }

        #endregion

        #region Iznajmi/Vrati

        public IActionResult Iznajmi(int id)
        {
            var asset = _assets.GetById(id);

            var model = new IznajmljivanjeModel
            {
                AssetId = id,
                ImgUrl = asset.ImgUrl,
                Naziv = asset.Naziv,
                ClanskaKartaId = "",
                isIznajmljeno = _iznajmljivanje.IsIznajmljeno(id)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult PotvrdiIznajmljivanje(int assetId, int clanskaKartaId)
        {
            _iznajmljivanje.IznajmiItem(assetId, clanskaKartaId);
            return RedirectToAction("Detail", new {id = assetId});
        }

        public IActionResult Vrati(int id)
        {
            _iznajmljivanje.VratiItem(id);
            return RedirectToAction("Detail", new {id = id});
        }

        #endregion

        #region Rezervisi

        public IActionResult Rezervisi(int id)
        {
            var asset = _assets.GetById(id);

            var model = new IznajmljivanjeModel
            {
                AssetId = id,
                ImgUrl = asset.ImgUrl,
                Naziv = asset.Naziv,
                ClanskaKartaId = "",
                isIznajmljeno = _iznajmljivanje.IsIznajmljeno(id),
                RezervacijeCount = _iznajmljivanje.GetCurrentRezervacije(id).Count()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult PotvrdiRezervaciju(int assetId, int clanskaKartaId)
        {
            _iznajmljivanje.Rezervisi(assetId, clanskaKartaId);
            return RedirectToAction("Detail", new {id = assetId});
        }

        #endregion
    }
}