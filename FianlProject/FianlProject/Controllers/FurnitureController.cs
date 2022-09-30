using FianlProject.DAL;
using FianlProject.Models;
using FianlProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FianlProject.Controllers
{
	public class FurnitureController : Controller
	{
		private readonly AppDbContext _context;
		private readonly UserManager<AppUser> _userManager;

		public FurnitureController(AppDbContext context, UserManager<AppUser> userManager)
		{
			_context = context;
			_userManager = userManager;
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
				.Include(c=>c.Comments).ThenInclude(c=>c.AppUser)
				.Include(c => c.Rates).ThenInclude(c=>c.AppUser)
				.FirstOrDefaultAsync(c => c.Id == id);
			return View(furniture);
		}

		[HttpGet]
		public async Task<IActionResult> AddRate(int id, byte point)
		{
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

			Rate Rate = new Rate
			{
				Date = DateTime.Now,
				AppUser = user,
				FurnitureId = id,
				Point = point
			};
			_context.Rates.Add(Rate);
			_context.SaveChanges();
			return Json("Oke");
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> AddComment(Comment comment)
		{
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (!ModelState.IsValid) return RedirectToAction("Detail", "Furniture", new { id = comment.FurnitureId });
			if (!_context.Furnitures.Any(f => f.Id == comment.FurnitureId)) return NotFound();
			Comment cmnt = new Comment
			{
				Text = comment.Text,
				FurnitureId = comment.FurnitureId,
				Date = DateTime.Now,
				AppUserId = user.Id,
			};
			_context.Comments.Add(cmnt);
			_context.SaveChanges();
			return RedirectToAction("Detail", "Furniture", new { id = comment.FurnitureId });
		}

		public async Task<IActionResult> DeleteComment(int id)
		{
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (!ModelState.IsValid) return RedirectToAction("Detail", "Book");
			if (!_context.Comments.Any(c => c.Id == id && c.AppUserId == user.Id)) return NotFound();
			Comment comment = _context.Comments.FirstOrDefault(c => c.Id == id && c.AppUserId == user.Id);
			_context.Comments.Remove(comment);
			_context.SaveChanges();
			return RedirectToAction("Detail", "Furniture", new { id = comment.FurnitureId });
		}

		//// rate pr id user id
		//// rate rate user id pr id 5
		/// text user id product id 




	}
}
