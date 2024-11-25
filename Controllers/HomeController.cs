using EcoFarm.data;
using EcoFarm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EcoFarm.Dtos;

namespace EcoFarm.Controllers
{
    public class HomeController : Controller
    {
        readonly private ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public IActionResult Autenticar([FromBody] LoginDto login)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(login.Usuario) || string.IsNullOrWhiteSpace(login.Senha))
                {
                    return Json(new { sucesso = false, mensagem = "Usuário ou senha não podem estar vazios." });
                }

                var conta = _db.CONTA
                    .Where(c => c.nome_usuario == login.Usuario && c.senha == login.Senha)
                    .Select(c => new { c.nome_usuario }) // Seleciona apenas o necessário
                    .FirstOrDefault();

                if (conta != null)
                {
                    return Json(new { sucesso = true, mensagem = "Login realizado com sucesso!" });
                }
                return Json(new { sucesso = false, mensagem = "Usuário e senha não cadastrados ou incorretos." });
            }
            catch (Exception ex)
            {
                return Json(new { sucesso = false, mensagem = $"Erro ao autenticar: {ex.Message}" });
            }
        }

        public IActionResult Index()
        {
            var tema = "loginECadastro";
            ViewBag.tema = tema;
            return View("~/Views/Tema/"+tema+"/Home/Index.cshtml"   );
        }

    }
}
