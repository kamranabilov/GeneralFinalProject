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
using System.Numerics;
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
			ViewBag.Category = _context.Categories.ToList();
			List<Furniture> furniture =await _context.Furnitures.Include(f => f.Categories).Skip((page - 1) * 4).Take(16).ToListAsync();
			ViewBag.CurentPage = page;
			ViewBag.TotalPage = Math.Ceiling((decimal)_context.Furnitures.Count() / 4);
			return View(furniture);
		}

		public async Task<IActionResult> GetDatas(string sortingOrder)
		{
			//ViewBag.Category = _context.Categories.ToList();
			List<Furniture> furniture = await _context.Furnitures.Include(f => f.Categories).ToListAsync();

			//sorting
			switch (sortingOrder)
			{
				case "A-Z":
					furniture = furniture.OrderByDescending(furnitures => furnitures.Name).ToList();
					break;
				case "Z-A":
					furniture = furniture.OrderBy(furnitures => furnitures.Name).ToList();
					break;
				case "Price by ascending":
					furniture = furniture.OrderBy(furnitures => furnitures.Price).ToList();
					break;
				case "Price by descending":
					furniture = furniture.OrderByDescending(furnitures => furnitures.Price).ToList();
					break;
				default:
					furniture = furniture.OrderBy(furnitures => furnitures.Id).ToList();
					break;
			}
			return View("Index", furniture.OrderBy(s=>s.Id).Take(12).ToList());
			//return PartialView("Index",homeVM);
		}

		//PartialView
		public async Task<IActionResult> ModalShopView(int? id)
		{
			Furniture furniture = await _context.Furnitures.Include(p => p.Furnitureimages).FirstOrDefaultAsync(p => p.Id == id);
			return PartialView("_ModalPartialView", furniture);
		}



		//public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
		//{
		//	ViewData["CurrentSort"] = sortOrder;
		//	ViewData["StatusSortParm"] = String.IsNullOrEmpty(sortOrder) ? "stat_desc" : "";
		//	ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

		//	if (searchString != null)
		//	{
		//		page = 1;
		//	}
		//	else
		//	{
		//		searchString = currentFilter;
		//	}

		//	ViewData["CurrentFilter"] = searchString;

		//	var patients = from s in _context.Furnitures
		//				   select s;
		//	var patient_id = 0;
		//	if (!String.IsNullOrEmpty(searchString))
		//	{
		//		patients = patients.Where(s => s.Name.Contains(searchString));
		//		bool result = Int32.TryParse(searchString, out Furnitureimage);
		//		if (result)
		//		{
		//			patients = patients.Where(s => s.FurnitureDescriptionId == patient_id);

		//		}
		//	}
		//	switch (sortOrder)
		//	{
		//		case "stat_desc":
		//			patients = patients.OrderByDescending(s => s.Name);
		//			break;
		//		case "Date":
		//			patients = patients.OrderBy(s => s.Price);
		//			break;
		//		case "date_desc":
		//			patients = patients.OrderByDescending(s => s.Article);
		//			break;
		//		default:
		//			patients = patients.OrderBy(s => s.Name);
		//			break;
		//	}
		//	int pageSize = 15;
		//	return View(await PaginatedList<Patient>.CreateAsync(patients.AsNoTracking(), page ?? 1, pageSize));
		//}
	}
}
