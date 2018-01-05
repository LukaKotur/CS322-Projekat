using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CS322_Projekat.Models.IznajmljivanjeModels;
using CS322_Projekat.Models.Katalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.Net.Http.Headers;
using ProjekatData;
using ProjekatData.Models;

namespace CS322_Projekat.Controllers
{
    [Authorize]
    public class KatalogController : Controller
    {
        #region Fields/Constructor

        private IVideoKlubAsset _assets;
        private IIznajmljivanje _iznajmljivanje;
        private IHostingEnvironment _environment;
        private DataContext _context;

        public KatalogController(IVideoKlubAsset assets, IIznajmljivanje iznajmljivanje,
            IHostingEnvironment environment, DataContext context)
        {
            _assets = assets;
            _iznajmljivanje = iznajmljivanje;
            _environment = environment;
            _context = context;
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
                    GlavniGlumci = _assets.GetGlavniGlumci(res.Id),
                    Status = res.Status.Naziv
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

        #region Add/Remove

        public IActionResult Add()
        {
            var vm = new KatalogAddModel();

            vm.SveLokacije = _context.VideoKlubOgranak.Select(a => new SelectListItem()
            {
                Value = a.Id.ToString(),
                Text = a.Naziv
            }).ToList();

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddPost(string naziv, string datumIzlaska, decimal cena, int lokacijaId,
            string producent, string glavniGlumci)
        {
            Film asset = new Film();
            asset.Naziv = naziv;
            asset.DatumIzlaska = DateTime.ParseExact(datumIzlaska, "MM/dd/yyyy", null);
            asset.Cena = cena;
            asset.BrojKopija = 1;
            asset.Producent = producent;
            asset.GlavniGlumci = glavniGlumci;
            asset.Status = _context.Status
                .FirstOrDefault(a => a.Naziv == "Dostupan");
            asset.Lokacija = _context.VideoKlubOgranak.FirstOrDefault(a => a.Id == lokacijaId);

            var newFileName = string.Empty;
            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = HttpContext.Request.Form.Files;
                

                foreach (var file in files)
                {
                    if (file.FileName == "")
                    {
                        asset.ImgUrl = "/images/default-image.jpg";
                    }
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString()
                            .Trim('"');

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var FileExtension = Path.GetExtension(fileName);

                        // concating  FileName + FileExtension
                        newFileName = myUniqueFileName + FileExtension;

                        // Combines two strings into a path.
                        fileName = Path.Combine(_environment.WebRootPath, "images") + $@"\{newFileName}";

                        // if you want to store path of folder in database
                        PathDB = "/images/" + newFileName;

                        asset.ImgUrl = PathDB;
                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }
            }

            _assets.Add(asset);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            _assets.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Film film = (Film) _assets.GetById(id);
            var vm = new KatalogAddModel
            {
                SveLokacije = _context.VideoKlubOgranak.Select(a => new SelectListItem()
                {
                    Value = a.Id.ToString(),
                    Text = a.Naziv
                }).ToList(),
                Naziv = film.Naziv,
                GlavniGlumci = film.GlavniGlumci,
                Cena = film.Cena,
                DatumIzlaska = film.DatumIzlaska,
                Producent = film.Producent,
                Lokacija = film.Lokacija,
                LokacijaId = film.Lokacija.Id
            };


            return View(vm);
        }

        [HttpPost]
        public IActionResult EditPost( int id, string naziv, string datumIzlaska, decimal cena, int lokacijaId,
            string producent, string glavniGlumci)
        {
            Film asset = (Film) _assets.GetById(id);

            asset.Naziv = naziv;
            datumIzlaska = datumIzlaska.Substring(0, 10);
            asset.DatumIzlaska = DateTime.ParseExact(datumIzlaska, "dd/MM/yyyy", null);
            asset.Cena = cena;
            asset.BrojKopija = 1;
            asset.Producent = producent;
            asset.GlavniGlumci = glavniGlumci;

            asset.Lokacija = _context.VideoKlubOgranak.FirstOrDefault(a => a.Id == lokacijaId);

            var newFileName = string.Empty;
            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString()
                            .Trim('"');

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var FileExtension = Path.GetExtension(fileName);

                        // concating  FileName + FileExtension
                        newFileName = myUniqueFileName + FileExtension;

                        // Combines two strings into a path.
                        fileName = Path.Combine(_environment.WebRootPath, "images") + $@"\{newFileName}";

                        // if you want to store path of folder in database
                        PathDB = "/images/" + newFileName;

                        asset.ImgUrl = PathDB;
                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }
            }

            _assets.Edit(id);
            return RedirectToAction("Index");
        }

        #endregion
    }
}