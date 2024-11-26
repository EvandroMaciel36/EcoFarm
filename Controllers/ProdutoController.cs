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

        public IActionResult Legumes()
        {
            var produtos = _db.PRODUTO
                .Where(p => p.Categoria.ToLower() == "legume")
                .ToList();

            var tema = "siteECompra";
            ViewBag.tema = tema;
            return View("~/Views/Tema/" + tema + "/Produto/Categoria.cshtml", produtos);
        }

        public IActionResult Frutas()
        {
            var produtos = _db.PRODUTO
                .Where(p => p.Categoria.ToLower() == "fruta")
                .ToList();

            var tema = "siteECompra";
            ViewBag.tema = tema;
            return View("~/Views/Tema/" + tema + "/Produto/Categoria.cshtml", produtos);
        }

        public IActionResult Verduras()
        {
            var produtos = _db.PRODUTO
                .Where(p => p.Categoria.ToLower() == "verdura")
                .ToList();

            var tema = "siteECompra";
            ViewBag.tema = tema;
            return View("~/Views/Tema/" + tema + "/Produto/Categoria.cshtml", produtos);
        }



        [HttpGet]
        public IActionResult Buscar(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
            {
                return Json(new List<object>()); 
            }

            var produtos = _db.PRODUTO
                .Where(p => p.Nome.Contains(termo) || p.Descricao.Contains(termo) || p.Categoria.Contains(termo))
                .Select(p => new
                {
                    id = p.Id_produto,
                    nome = p.Nome,
                    descricao = p.Descricao,
                    preco = p.Preco,
                    categoria = p.Categoria,
                    caminhoImagem = p.Caminho_imagem
                })
                .ToList();

            return Json(produtos);
        }



        public IActionResult Detalhes(int id)
        {
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
