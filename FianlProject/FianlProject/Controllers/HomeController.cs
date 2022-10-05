using FianlProject.DAL;
using FianlProject.ViewModels;
using FianlProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace FianlProject.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;

		public HomeController(AppDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index(string str)
		{
			//str = "bed";
			HomeVM homeVM = new HomeVM
			{
				Sliders = await _context.Sliders.ToListAsync(),
				Furnitures = await _context.Furnitures.Include(c=>c.Rates).Include(c => c.Furnitureimages).ToListAsync(),
				Categories = await _context.Categories.Include(c => c.Furnitures).ToListAsync(),
				Contacts = await _context.Contacts.ToListAsync(),
				Rates = await _context.Rates.ToListAsync(),
				Orders = await _context.Orders.ToListAsync(),
				OrderItems=await _context.OrderItems.ToListAsync(),
			};


			if (!string.IsNullOrWhiteSpace(str))
			{
				List<Furniture> furnitures = _context.Furnitures.Include(x => x.Furnitureimages).Where(x => x.Name.Trim().ToLower().Contains(str)).ToList();
				homeVM.Furnitures = furnitures;
			}
			else
			{
				homeVM.Furnitures = _context.Furnitures.Include(x => x.Furnitureimages).ToList();
			}
			return View(homeVM);
		}

		public async Task<IActionResult> Faq()
		{
			List<Faq> faqs = await _context.Faqs.ToListAsync();
			return View(faqs);
		}

		public async Task<IActionResult> About()
		{
			ViewBag.furniture = _context.Furnitures.ToList();
			ViewBag.user = _context.Users.ToList();
			List<About> abouts = await _context.Abouts.ToListAsync();		
			return View(abouts);
		}
	}
}
