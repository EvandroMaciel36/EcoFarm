using EcoFarm.data;
using EcoFarm.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoFarm.Controllers
{
    public class CarrinhoController : Controller
    {
        readonly private ApplicationDbContext _db;

        public CarrinhoController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var tema = "siteECompra";
            ViewBag.tema = tema;
            return View("~/Views/Tema/" + tema + "/Carrinho/Index.cshtml");
        }
    }
}
