using EcoFarm.data;
using EcoFarm.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoFarm.Controllers
{
    public class CadastroController : Controller
    {

        readonly private ApplicationDbContext _db;
        public CadastroController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var tema = "loginECadastro";
            ViewBag.tema = tema;
            IEnumerable<CadastroModel> cadastro = _db.CONTA;
            return View("~/Views/Tema/"+tema+"/Cadastro/Index.cshtml", cadastro);
        }
    }
}
