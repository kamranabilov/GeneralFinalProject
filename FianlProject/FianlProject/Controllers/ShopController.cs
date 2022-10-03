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
		public async Task<IActionResult> Index(int? id, string sortingOrder, int pagimax, int pagimin, int page = 1)
		{
			int max = 8;
			if (id != 0 || id != null)
			{
				if (!string.IsNullOrEmpty(sortingOrder))
				{
					double pageCountsort = Math.Ceiling((double)((decimal)_context.Furnitures.Count() / Convert.ToDecimal(max)));
					ViewBag.CurentPage = page;
					ViewBag.TotalPage = pageCountsort;

					HomeVM sort = new HomeVM
					{
						Furnitures = _context.Furnitures.Include(f => f.Rates).Include(f => f.Categories).ToList(),
						Categories = _context.Categories.Include(c => c.Furnitures).ToList(),

					};
					switch (sortingOrder)
					{
						case "A-Z":
							sort.Furnitures = sort.Furnitures.OrderBy(Furnitures => Furnitures.Name).Skip((page - 1) * 4).Take(max).ToList();
							break;
						case "Z-A":
							sort.Furnitures = sort.Furnitures.OrderByDescending(Furnitures => Furnitures.Name).Skip((page - 1) * 4).Take(max).ToList();
							break;
						case "Price by ascending":
							sort.Furnitures = sort.Furnitures.OrderBy(Furnitures => Furnitures.Price).Skip((page - 1) * 4).Take(max).ToList();
							break;
						case "Price by descending":
							sort.Furnitures = sort.Furnitures.OrderByDescending(Furnitures => Furnitures.Price).Skip((page - 1) * 4).Take(max).ToList();
							break;
						default:
							sort.Furnitures = sort.Furnitures.OrderBy(Furnitures => Furnitures.Id).Skip((page - 1) * 4).Take(max).ToList();
							break;
					}
					return View(sort);
				}
				Category category = await _context.Categories
					.Include(c => c.Furnitures).ThenInclude(c => c.Rates).Include(c => c.Furnitures).ThenInclude(c => c.Furnitureimages).Skip((page - 1) * 4).Take(4)
					.FirstOrDefaultAsync(x => x.Id == id);
				double pageCount = Math.Ceiling((double)((decimal)_context.Furnitures.Count() / Convert.ToDecimal(max)));
				ViewBag.CurentPage = page;
				ViewBag.TotalPage = pageCount;
				if (category != null)
				{
					if (category.Furnitures.Count() != 0)
					{
						HomeVM home = new HomeVM
						{
							Categories = _context.Categories.ToList(),
							Furnitures = category.Furnitures
						};
						return View(home);
					}
					else
					{
						ViewBag.Message = "category";
						return View();
					}
				}

				if (pagimax != 0 || pagimin != 0)
				{
					ViewBag.TotalPage = Math.Ceiling((decimal)_context.Furnitures.Where(m => m.Price > pagimin && m.Price < pagimax).Count() / 4);
					ViewBag.CurrentPage = page;
					HomeVM filter = new HomeVM
					{
						Furnitures = _context.Furnitures.Include(f => f.Categories).Where(m => m.Price > pagimin && m.Price < pagimax).Skip((page - 1) * 4).Take(4).ToList(),
						Categories = _context.Categories.Include(c => c.Furnitures).ToList(),
					};
					return View(filter);

				}
			}
			HomeVM homeVM = new HomeVM
			{
				Categories= _context.Categories.ToList(),
				Furnitures = _context.Furnitures.Include(f => f.Categories).Skip((page - 1) * max).Take(max).ToList()

			};

			return View(homeVM);
		}	

		
			
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
