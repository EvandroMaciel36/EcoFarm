using EcoFarm.data;
using EcoFarm.Models;
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

        public IActionResult Index()
        {
            var tema = "siteECompra";
            ViewBag.tema = tema;

            // Buscar itens do carrinho no banco de dados
            var itensCarrinho = _db.CARRINHO.ToList();

            // Enviar os itens para a view
            return View($"~/Views/Tema/{tema}/Carrinho/Index.cshtml", itensCarrinho);
        }


        [HttpPost]
        public IActionResult AdicionarAoCarrinho(int id, string nome, decimal preco, int quantidade)
        {
            Console.WriteLine($"Recebido: Id={id}, Nome={nome}, Preço={preco}, Quantidade={quantidade}");
            if (quantidade <= 0)
            {
                return Json(new { sucesso = false, mensagem = "A quantidade deve ser maior que zero." });
            }

            var itemExistente = _db.CARRINHO.FirstOrDefault(i => i.Id == id);
            if (itemExistente != null)
            {
                // Atualizar quantidade
                itemExistente.Quantidade += quantidade;
                _db.CARRINHO.Update(itemExistente);
            }
            else
            {
                // Adicionar novo item
                _db.CARRINHO.Add(new CarrinhoModel
                {
                    Id = id,
                    Nome = nome,
                    Preco = preco,
                    Quantidade = quantidade
                });
            }

            _db.SaveChanges();

            return Json(new { sucesso = true, mensagem = "Produto adicionado ao carrinho." });
        }

        [HttpPost]
        public IActionResult AtualizarQuantidade(int id, int quantidade)
        {
            if (quantidade <= 0)
            {
                return Json(new { sucesso = false, mensagem = "A quantidade deve ser maior que zero." });
            }

            var item = _db.CARRINHO.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.Quantidade = quantidade;
                _db.CARRINHO.Update(item);
                _db.SaveChanges();

                return Json(new { sucesso = true, totalItem = item.Total });
            }

            return Json(new { sucesso = false, mensagem = "Item não encontrado." });
        }


        [HttpPost]
        public IActionResult RemoverItem(int id)
        {
            var item = _db.CARRINHO.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _db.CARRINHO.Remove(item);
                _db.SaveChanges();
            }

            return Json(new { sucesso = true, mensagem = "Produto removido do carrinho." });
        }
    }
}
