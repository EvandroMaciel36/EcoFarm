using EcoFarm.Models;
using EcoFarm.data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EcoFarm.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PagamentoController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Exibir página de pagamento
        [HttpGet]
        public IActionResult Index()
        {
            var carrinho = _db.CARRINHO.ToList();
            var tema = "siteECompra";
            ViewBag.tema = tema;
            return View("~/Views/Tema/" + tema + "/Pagamento/Pagamento.cshtml", carrinho);
        }

        // Processar pagamento
        [HttpPost]
        public IActionResult ProcessarPagamento(string metodoPagamento)
        {
            // Verificar se o método de pagamento foi selecionado
            if (string.IsNullOrEmpty(metodoPagamento))
            {
                TempData["Erro"] = "Por favor, selecione um método de pagamento.";
                return RedirectToAction("Index");
            }

            // Simular o processamento do pagamento
            TempData["Sucesso"] = "Pagamento realizado com sucesso usando: " + metodoPagamento;

            // Limpar o carrinho após o pagamento ser concluído
            var itensCarrinho = _db.CARRINHO.ToList();
            if (itensCarrinho.Any())
            {
                _db.CARRINHO.RemoveRange(itensCarrinho);
                _db.SaveChanges();
            }

            // Redirecionar para a página de confirmação
            return RedirectToAction("Confirmacao");
        }

        // Página de confirmação
        [HttpGet]
        public IActionResult Confirmacao()
        {
            var tema = "siteECompra";
            ViewBag.tema = tema;
            return View("~/Views/Tema/" + tema + "/Pagamento/Confirmacao.cshtml");
        }
    }
}
