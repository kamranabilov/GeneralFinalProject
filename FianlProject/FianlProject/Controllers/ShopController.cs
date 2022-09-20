using Microsoft.AspNetCore.Mvc;

namespace FianlProject.Controllers
{
	public class ShopController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
