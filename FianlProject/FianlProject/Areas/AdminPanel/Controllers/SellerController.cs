using FianlProject.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FianlProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace FianlProject.Areas.AdminPanel.Controllers
{
	[Area("AdminPanel")]
	[Authorize(Roles = "Admin")]
	public class SellerController : Controller
    {
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _env;

		public SellerController(AppDbContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}

		public async Task<IActionResult> Index(int page = 1)
		{
			int max = 8;
			double pageCountsort = Math.Ceiling((double)((decimal)_context.Furnitures.Count() / Convert.ToDecimal(max)));
			List<Furniture> model = await _context.Furnitures.Include(c => c.Categories).Include(c => c.Furnitureimages).Skip((page - 1) * 5).Take(5).ToListAsync();
			ViewBag.CurentPage = page;
			ViewBag.TotalPage = pageCountsort;
			return View(model);
		}
		public async Task<IActionResult> Trend(int id)
		{
			Furniture furniture = _context.Furnitures.FirstOrDefault(m => m.Id == id);
			if (furniture.Trend == false)
			{
				furniture.Trend = true;
			}
			else if (furniture.Trend == true)
			{
				furniture.Trend = false;
			}
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}

	}
}
