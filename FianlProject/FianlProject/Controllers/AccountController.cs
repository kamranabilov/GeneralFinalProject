using Microsoft.AspNetCore.Mvc;

namespace FianlProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
