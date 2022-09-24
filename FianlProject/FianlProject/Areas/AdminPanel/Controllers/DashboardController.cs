using FianlProject.DAL;
using FianlProject.Models;
using FianlProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FianlProject.Areas.AdminPanel.Controllers
{
	[Area("AdminPanel")]
	public class DashboardController : Controller
	{
		private readonly AppDbContext _context;

		public DashboardController(AppDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			HomeVM homeVM = new HomeVM
			{
				Sliders = await _context.Sliders.ToListAsync(),
				Furnitures = await _context.Furnitures.Include(c => c.Furnitureimages).ToListAsync(),
				Categories = await _context.Categories.Include(c => c.Furnitures).ToListAsync(),
				Contacts = await _context.Contacts.ToListAsync()
			};
			return View(homeVM);
		}
	}
}
