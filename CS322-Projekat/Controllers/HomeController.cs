using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CS322_Projekat.Models;

namespace CS322_Projekat.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}