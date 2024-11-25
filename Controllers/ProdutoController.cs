using EcoFarm.Models;
using EcoFarm.data;
using Microsoft.AspNetCore.Mvc;

namespace EcoFarm.Controllers
{
    public class ProdutoController : Controller
    {
        readonly private ApplicationDbContext _db;

        public ProdutoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Detalhes(int id)
        {
            // Obtém o produto pelo ID
            var produto = _db.PRODUTO.FirstOrDefault(p => p.Id_produto == id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            var tema = "siteECompra";
            ViewBag.tema = tema;
            return View("~/Views/Tema/"+ tema + "/Produto/Detalhes.cshtml", produto);
        }
    }
}
