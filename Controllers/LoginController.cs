using EcoFarm.data;
using EcoFarm.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoFarm.Controllers
{
    public class LoginController : Controller
    {

        readonly private ApplicationDbContext _db;
        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<LoginModel> login = _db.CONTA;
            return View();
        }
    }
}
