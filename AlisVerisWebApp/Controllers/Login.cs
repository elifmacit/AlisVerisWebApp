using Microsoft.AspNetCore.Mvc;

namespace AlisVerisWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
