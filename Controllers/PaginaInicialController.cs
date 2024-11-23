using EcoFarm.data;
using EcoFarm.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoFarm.Controllers
{
    public class PaginaInicialController : Controller
    {
        readonly private ApplicationDbContext _db;

        public PaginaInicialController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var tema = "siteECompra";
            ViewBag.tema = tema;
            IEnumerable<ProdutoModel> produtos = _db.PRODUTO;
            return View("~/Views/Tema/" + tema + "/PaginaInicial/Index.cshtml", produtos);
        }
    }
}
