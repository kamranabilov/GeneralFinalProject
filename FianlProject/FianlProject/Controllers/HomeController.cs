using FianlProject.DAL;
using FianlProject.ViewModels;
using FianlProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FianlProject.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;

		public HomeController(AppDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			HomeVM homeVM = new HomeVM
			{
				Sliders =await _context.Sliders.ToListAsync(),
				Furnitures = await _context.Furnitures.Include(c => c.Furnitureimages).ToListAsync(),
				Categories =await _context.Categories.Include(c => c.Furnitures).ToListAsync(),
				Contacts = await _context.Contacts.ToListAsync()
			};
			return View(homeVM);
		}

		public async Task<IActionResult> Faq()
		{
			List<Faq> faqs = await _context.Faqs.ToListAsync();
			return View(faqs);
		}
	}
}
