using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CS322_Projekat.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Rest;
using ProjekatData;

namespace CS322_Projekat.Controllers
{
    public class HomeController : Controller
    {
        private IZaposleni _zaposleni;

        public HomeController(IZaposleni zaposleni)
        {
            _zaposleni = zaposleni;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [HttpPost]
        public async Task<IActionResult> Login(int id, string ime, string password)
        {
            var zaposleni = _zaposleni.Get(id, ime);

            if (string.IsNullOrEmpty(ime) || string.IsNullOrEmpty(password))
            {
                return RedirectToAction(nameof(Index));
            }

            if (zaposleni.Sifra == password)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, zaposleni.Ime),
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ErrorLogin() => View();
    }
}