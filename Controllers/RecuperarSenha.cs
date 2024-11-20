using Microsoft.AspNetCore.Mvc;

namespace EcoFarm.Controllers
{
    public class RecuperarSenha : Controller
    {
        public IActionResult Index()
        {
            var tema = "loginECadastro";
            ViewBag.tema = tema;
            return View("~/Views/Tema/" + tema + "/RecuperarSenha/Index.cshtml");
        }
    }
}
