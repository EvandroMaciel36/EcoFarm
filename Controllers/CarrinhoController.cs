using EcoFarm.Models;
using EcoFarm.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EcoFarm.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CarrinhoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult LimparCarrinho()
        {
            var carrinho = _db.CARRINHO.ToList(); // Recupera todos os itens do carrinho

            if (carrinho != null && carrinho.Any())
            {
                _db.CARRINHO.RemoveRange(carrinho); // Remove todos os itens do carrinho
                _db.SaveChanges(); // Salva as alterações no banco de dados
            }

            // Redireciona para uma página de sucesso (opcional)
            return RedirectToAction("PagamentoConcluido");
        }

        /// <summary>
        /// Exibe os itens no carrinho do cliente.
        /// </summary>
        public IActionResult Index()
        {
            // Carrega os itens do carrinho com os dados do produto
            var carrinho = _db.CARRINHO
                .Include(c => c.Produto) // Carrega os dados do Produto associado
                .ToList();

            var tema = "siteECompra";
            ViewBag.tema = tema;
            return View("~/Views/Tema/" + tema + "/Carrinho/Index.cshtml", carrinho);
        }

        /// <summary>
        /// Adiciona um item ao carrinho.
        /// </summary>
        [HttpPost]
        public IActionResult AdicionarAoCarrinho([FromBody] CarrinhoModel carrinho)
        {
            if (carrinho == null || carrinho.Quantidade <= 0)
            {
                return Json(new { sucesso = false, mensagem = "Quantidade inválida." });
            }

            // Busca o produto pelo ID
            var produto = _db.PRODUTO.FirstOrDefault(p => p.Id_produto == carrinho.Id_produto);
            if (produto == null)
            {
                return Json(new { sucesso = false, mensagem = "Produto não encontrado." });
            }

            // Preenche os dados do carrinho
            carrinho.Nome_produto = produto.Nome;
            carrinho.Preco_unitario = produto.Preco;
            carrinho.Preco_total = produto.Preco * carrinho.Quantidade;

            // Adiciona ao banco de dados
            _db.CARRINHO.Add(carrinho);
            _db.SaveChanges();

            return Json(new { sucesso = true, mensagem = "Produto adicionado ao carrinho com sucesso!" });
        }

        /// <summary>
        /// Remove um item do carrinho.
        /// </summary>
        [HttpPost]
        [HttpPost]
        public IActionResult RemoverDoCarrinho(int id)
        {
            var itemCarrinho = _db.CARRINHO.FirstOrDefault(c => c.Id_carrinho == id);
            if (itemCarrinho == null)
            {
                return Json(new { sucesso = false, mensagem = "Item do carrinho não encontrado." });
            }

            _db.CARRINHO.Remove(itemCarrinho);
            _db.SaveChanges();

            return Json(new { sucesso = true, mensagem = "Item removido do carrinho com sucesso!" });
        }

    }
}
