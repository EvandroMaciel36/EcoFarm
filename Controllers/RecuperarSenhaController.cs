using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using EcoFarm.data;
using Microsoft.EntityFrameworkCore;
using EcoFarm.Dtos;

namespace EcoFarm.Controllers
{
    public class RecuperarSenhaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RecuperarSenhaController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult RecuperarSenha([FromBody] RecuperarSenhaDto dto)
        {
            try
            {
                // Chamar a stored procedure usando os valores do DTO
                var resultado = _db.Database.ExecuteSqlRaw(
                    "EXEC S_RecuperarSenha @NomeUsuario, @Email, @NovaSenha",
                    new SqlParameter("@NomeUsuario", dto.NomeUsuario),
                    new SqlParameter("@Email", dto.Email),
                    new SqlParameter("@NovaSenha", dto.NovaSenha)
                );

                // Verificar se a operação foi bem-sucedida
                if (resultado > 0)
                {
                    return Json(new { sucesso = true, mensagem = "Senha alterada com sucesso!" });
                }
                else
                {
                    return Json(new { sucesso = false, mensagem = "Senha alterada com sucesso!" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { sucesso = false, mensagem = "Erro ao recuperar senha.", erro = ex.Message });
            }
        }


        public IActionResult Index()
        {
            var tema = "loginECadastro";
            ViewBag.tema = tema;
            return View("~/Views/Tema/" + tema + "/RecuperarSenha/Index.cshtml");
        }
    }
}
