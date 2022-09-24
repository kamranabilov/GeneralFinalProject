using FianlProject.DAL;
using FianlProject.Models;
using FianlProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace FianlProject.Controllers
{
	public class ShopController : Controller
	{
		private readonly AppDbContext _context;

		public ShopController(AppDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index(int page = 1)
		{

			List<Furniture> furniture =await _context.Furnitures.Include(f => f.Categories).ToListAsync();
			return View(furniture);
		}

		public async Task<IActionResult> GetDatas(string sortingOrder)
		{
			List<Furniture> furniture = await _context.Furnitures.Include(f => f.Categories).ToListAsync();
			//sorting
			switch (sortingOrder)
			{
				case "A-Z":
					furniture = furniture.OrderByDescending(furnitures => furnitures.Name).ToList();
					break;
				case "Z-A":
					furniture = furniture.OrderByDescending(furnitures => furnitures.Name).ToList();
					break;
				case "Price by ascending":
					furniture = furniture.OrderBy(furnitures => furnitures.Price).ToList();
					break;
				case "Price by descending":
					furniture = furniture.OrderByDescending(furnitures => furnitures.Price).ToList();
					break;
				default:
					furniture = furniture.OrderByDescending(furnitures => furnitures.Id).ToList();
					break;
			}
			return PartialView("_shopPartial", furniture.OrderByDescending(s=>s.Id).Take(8).ToList());
			//return PartialView("Index",homeVM);
		}
	}
}
