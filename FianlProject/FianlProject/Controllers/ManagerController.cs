using FianlProject.DAL;
using FianlProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FianlProject.Controllers
{
    public class ManagerController : Controller
    {
		private readonly AppDbContext _context;
		private readonly UserManager<AppUser> _userManager;

		public ManagerController(AppDbContext context, UserManager<AppUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (user == null) return NotFound();
			AppUser name = await _context.Users.Include(n => n.Orders).FirstOrDefaultAsync(n => n.Id == user.Id);
			return View(name);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Index(AppUser usernew)
		{
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (!ModelState.IsValid) return View("This is error msg");
			if (usernew == null) return NotFound();
			user.FirstName = usernew.FirstName;
			user.LastName = usernew.LastName;
			user.Email = usernew.Email;
			_context.SaveChanges();
			TempData["name"] = "Succsses";
			return RedirectToAction(nameof(Index));
		}
	}
}
