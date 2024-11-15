using EcoFarm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcoFarm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var tema = "loginECadastro";
            ViewBag.tema = tema;
            return View("~/Views/Tema/"+tema+"/Home/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            var tema = "loginECadastro";
            ViewBag.tema = tema;
            return View("~/Views/Tema/" + tema + "/Home/Index.cshtml");
        }
    }
}
