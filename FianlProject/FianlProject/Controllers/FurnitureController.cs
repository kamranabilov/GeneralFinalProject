﻿using FianlProject.DAL;
using FianlProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FianlProject.Controllers
{
	public class FurnitureController : Controller
	{
		private readonly AppDbContext _context;

		public FurnitureController(AppDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Detail(int? id)
		{
			ViewBag.furniture = _context.Furnitures.ToList();
			ViewBag.Category = _context.Categories.ToList();
			ViewBag.Desc = _context.FurnitureDescriptions.ToList();
			if (id == 0 || id == null) return NotFound();
			Furniture furniture = await _context.Furnitures
				.Include(c => c.Furnitureimages)
			    .Include(c => c.FurnitureDescription)
			    .FirstOrDefaultAsync(c => c.Id == id);
			return View(furniture);
		}

		// Partial View
		//public async Task<IActionResult> Partial()
		//{
		//	List<Furniture> furnitures = await _context.Furnitures.Include(c => c.Furnitureimages).ToListAsync();
		//	return PartialView("_FurniturePartialView", furnitures);
		//}
	}
}