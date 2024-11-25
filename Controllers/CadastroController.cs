using EcoFarm.data;
using EcoFarm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EcoFarm.Controllers
{
    public class CadastroController : Controller
    {

        readonly private ApplicationDbContext _db;
        public CadastroController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public IActionResult Cadastrar([FromBody] CadastroDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Database.ExecuteSqlRaw(
                        "EXEC S_CadastrarClienteConta @Nome, @Email, @Telefone, @Endereco, @NomeUsuario, @Senha",
                        new SqlParameter("@Nome", dto.Nome),
                        new SqlParameter("@Email", dto.Email),
                        new SqlParameter("@Telefone", dto.Telefone),
                        new SqlParameter("@Endereco", dto.Endereco),
                        new SqlParameter("@NomeUsuario", dto.nome_usuario),
                        new SqlParameter("@Senha", dto.senha)
                    );

                    return Json(new { sucesso = true, mensagem = "Cadastro realizado com sucesso!" });
                }
                catch (Exception ex)
                {
                    return Json(new { sucesso = false, mensagem = "Erro ao cadastrar.", erro = ex.Message });
                }
            }

            return Json(new { sucesso = false, mensagem = "Dados inválidos.", erros = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList() });
        }

        public class CadastroDto
        {
            [Required]
            public string Nome { get; set; }
            [Required, EmailAddress]
            public string Email { get; set; }
            [Required]
            public string Telefone { get; set; }
            [Required]
            public string Endereco { get; set; }
            [Required]
            public string nome_usuario { get; set; }
            [Required]
            public string senha { get; set; }
        }



        public IActionResult Index()
        {
            var tema = "loginECadastro";
            ViewBag.tema = tema;
            return View("~/Views/Tema/"+tema+"/Cadastro/Index.cshtml");
        }
    }
}
