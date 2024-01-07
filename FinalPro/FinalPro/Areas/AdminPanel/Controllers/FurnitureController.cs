using FianlProject.DAL;
using FianlProject.Extensions;
using FianlProject.Models;
using FianlProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FianlProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
	//[Authorize(Roles = "Admin")]
	public class FurnitureController : Controller
    {
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _env;

		public FurnitureController(AppDbContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}
        public async Task<IActionResult> Index(int page = 1)
        {
			int max = 8;
			double pageCountsort = Math.Ceiling((double)((decimal)_context.Furnitures.Count() / Convert.ToDecimal(max)));
			
			List<Furniture> model =await _context.Furnitures
				.Include(c => c.FurnitureDescription)
				.Include(c => c.Categories)
				.Include(c => c.Furnitureimages).Include(f => f.Categories).Skip((page - 1) * max).Take(max).ToListAsync();
			ViewBag.CurentPage = page;
			ViewBag.TotalPage = pageCountsort;
			return View(model);
        }
		
		public IActionResult Create()
		{
			ViewBag.Description = _context.FurnitureDescriptions.ToList();
			ViewBag.Categories = _context.Categories.ToList();
			return View();
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Create(Furniture furniture)
		{
			ViewBag.Description = _context.FurnitureDescriptions.ToList();
			ViewBag.Categories = _context.Categories.ToList();
			if (!ModelState.IsValid) return View();
			if (furniture.MainPhoto == null || furniture.Photos == null)
			{
				ModelState.AddModelError(string.Empty, "must choose 1 main photo");
				return View();
			}
			if (!furniture.MainPhoto.ImageIsOkey(2))
			{
				ModelState.AddModelError(string.Empty, "choose image file");
				return View();
			}
			furniture.Image = await FileExtension.FileCreate(furniture.MainPhoto, _env.WebRootPath, "assets/image/shop");
			furniture.Furnitureimages = new List<Furnitureimage>();
			TempData["Filename"] = null;
			List<IFormFile> removeable = new List<IFormFile>();
			foreach (var photo in furniture.Photos.ToList())
			{
				if (!photo.ImageIsOkey(2))
				{
					removeable.Add(photo);
					TempData["Filename"] += photo.FileName + ",";
					continue;
				}
				Furnitureimage otherphoto = new Furnitureimage
				{
					Name = await photo.FileCreate(_env.WebRootPath, "assets/image/shop"),
					IsMain = false,
					Alternative = furniture.Name,
					Furniture = furniture
				};
				furniture.Furnitureimages.Add(otherphoto);
			}
			furniture.Furnitureimages.RemoveAll(c => removeable.Any(f => f.FileName == f.FileName));
			Furnitureimage main = new Furnitureimage
			{
				Name = furniture.Image,
				IsMain = true,
				Alternative = furniture.Name,
				Furniture = furniture
			};
			furniture.Furnitureimages.Add(main);

			await _context.Furnitures.AddAsync(furniture);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == 0 || id == null) return NotFound();
			if (!ModelState.IsValid) return View();
			Furniture furniture = await _context.Furnitures
				.Include(c => c.Furnitureimages)
				.Include(c => c.FurnitureDescription)
				.Include(c => c.Categories).SingleOrDefaultAsync(c => c.Id == id);
			if (furniture == null) return NotFound();

			ViewBag.Description = _context.FurnitureDescriptions.ToList();
			ViewBag.Category = _context.Categories.ToList();
			ViewBag.images = _context.Furnitureimages.ToList();
			return View(furniture);
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Edit(int? id, Furniture furniture)
		{
			ViewBag.Category = _context.Categories.ToList();
			ViewBag.images = _context.Furnitureimages.ToList();
			ViewBag.Description = _context.FurnitureDescriptions.ToList();
			Furniture existed = _context.Furnitures.Include(m => m.Furnitureimages).Include(m => m.Categories).FirstOrDefault(m => m.Id == id);
			if (existed == null) return NotFound();
			if (!ModelState.IsValid) return View();
			if (furniture.ImagesId == null && furniture.Photos == null)
			{
				ModelState.AddModelError(string.Empty, "Please choose at least one main photo");
				return View(existed);
			}
			if (furniture.MainPhoto == null)
			{
				furniture.Image = existed.Image;
			}
			TempData["FileName"] = default(string);

			if (furniture.Photos != null)
			{
				if (furniture.ImagesId is null)
				{
					foreach (Furnitureimage medicineImage in existed.Furnitureimages.Where(m => m.IsMain == false))
					{
						FileExtension.FileDelete(_env.WebRootPath, "assets/image/shop", medicineImage.Name);
					}
					existed.Furnitureimages.RemoveAll(p => p.IsMain == false);
				}
				else
				{
					List<Furnitureimage> furnitureimages = existed.Furnitureimages
					  .Where(p => p.IsMain == false && !furniture.ImagesId
					  .Contains(p.Id)).ToList();

					existed.Furnitureimages
						.RemoveAll(p => furnitureimages.Any(r => p.Id == r.Id));
				}
				foreach (IFormFile image in furniture.Photos.ToList())
				{
					if (furniture.Photos.Count == 0)
					{
						ModelState.AddModelError("Photos", "None of the detail images are valid type");
						return View(existed);
					}

					if (!image.ImageIsOkey(2))
					{
						furniture.Photos.Remove(image);
						TempData["FileName"] += image.FileName + ",";
						continue;
					}
					Furnitureimage photos = new Furnitureimage
					{
						Name = await image.FileCreate(_env.WebRootPath,
							"assets/image/shop"),
						IsMain = false,
						Furniture = existed,
						Alternative = furniture.Name,
					};
					await _context.Furnitureimages.AddAsync(photos);
				}

			}
			else
			{
				if (furniture.ImagesId is null)
				{
					foreach (Furnitureimage furnitureimage in existed.Furnitureimages.Where(m => m.IsMain == false))
					{
						FileExtension.FileDelete(_env.WebRootPath, "assets/image/shop", furnitureimage.Name);
					}
					existed.Furnitureimages.RemoveAll(p => p.IsMain == false);
				}
				else
				{
					List<Furnitureimage> furnitureimages = existed.Furnitureimages
					  .Where(p => p.IsMain == false && !furniture.ImagesId
					  .Contains(p.Id)).ToList();
					foreach (Furnitureimage fimage in furnitureimages)
					{
						FileExtension.FileDelete(_env.WebRootPath, "assets/image/shop", fimage.Name);
					}

					existed.Furnitureimages
						.RemoveAll(p => furnitureimages.Any(r => p.Id == r.Id));
				}
			}
			if (furniture.MainPhoto != null)
			{
				if (!furniture.MainPhoto.ImageIsOkey(2))
				{
					ModelState.AddModelError("Photos", "Please choose valid image file");
					return View(existed);
				}
				Furnitureimage main = new Furnitureimage
				{
					IsMain = true,
					Alternative = furniture.Name,
					Name = await furniture.MainPhoto
					.FileCreate(_env.WebRootPath,
					"assets/image/shop"),
					Furniture = existed,
				};
				furniture.Image = main.Name;
				string mainPhoto = existed.Furnitureimages
					.FirstOrDefault(p => p.IsMain == true).Name;
				FileExtension.FileDelete(_env.WebRootPath,
					"assets/image/shop", mainPhoto);
				existed.Furnitureimages.FirstOrDefault(p => p.IsMain == true).Name = main.Name;
				existed.Furnitureimages.FirstOrDefault(p => p.IsMain == true)
					.Alternative = main.Alternative;
			}
			_context.Entry(existed).CurrentValues.SetValues(furniture);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Detail(int? id)
		{
			if (id == null || id == 0) return NotFound();
			Furniture furniture = await _context.Furnitures.FirstOrDefaultAsync(c => c.Id == id);
			if (furniture == null) return NotFound();
			return View(furniture);
		}

		//public async Task<IActionResult> Delete(int? id)
		//{
		//	if (id == null || id == 0) return NotFound();
		//	Furniture furniture = await _context.Furnitures.FindAsync(id);
		//	List<Furnitureimage> furnitureimage = await _context.Furnitureimages.ToListAsync();
		//	foreach (Furnitureimage item in furnitureimage)
		//	{
		//		if (furniture.Id == item.FurnitureId)
		//		{
		//			var alternativpath = Path.Combine(_env.WebRootPath, "assets/image/shop", item.Name);
		//			System.IO.File.Delete(alternativpath);
		//		}
		//	}
		//	if (furniture == null) return NotFound();
		//	_context.Furnitures.Remove(furniture);
		//	var rootpath = Path.Combine(_env.WebRootPath, "assets/image/shop/" +
		//		"", furniture.Image);
			
		//	System.IO.File.Delete(rootpath);
		//	await _context.SaveChangesAsync();
		//	return RedirectToAction(nameof(Index));
		//}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || id == 0) return NotFound();
			Furniture furniture = await _context.Furnitures.FindAsync(id);
			if (furniture == null) return NotFound();
			OrderItem order = await _context.OrderItems.FirstOrDefaultAsync(o => o.FurnitureId == furniture.Id);
			if (order == null)
			{
				List<Furnitureimage> furnitureimages = await _context.Furnitureimages.ToListAsync();
				foreach (Furnitureimage item in furnitureimages)
				{
					if (furniture.Id == item.FurnitureId)
					{
						var alternativpath = Path.Combine(_env.WebRootPath, "assets/image/shop/", item.Name);
						System.IO.File.Delete(alternativpath);
					}
				}
			}
			else
			{
				TempData["orderitem"] = "Order cannot be deleted";
				return RedirectToAction(nameof(Index));
			}



			_context.Furnitures.Remove(furniture);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
