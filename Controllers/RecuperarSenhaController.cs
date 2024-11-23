using Microsoft.AspNetCore.Mvc;

namespace EcoFarm.Controllers
{
    public class RecuperarSenhaController : Controller
    {
        public IActionResult Index()
        {
            var tema = "loginECadastro";
            ViewBag.tema = tema;
            return View("~/Views/Tema/" + tema + "/RecuperarSenha/Index.cshtml");
        }
    }
}
