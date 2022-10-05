using FianlProject.DAL;
using FianlProject.Models;
using FianlProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
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
				.Include(c => c.Categories)
				.Include(c=>c.Comments).ThenInclude(c=>c.AppUser)
				.Include(c => c.Rates).ThenInclude(c=>c.AppUser)
				.FirstOrDefaultAsync(c => c.Id == id);
			return View(furniture);
		}

		[HttpGet]
		public async Task<IActionResult> AddRate(int id, byte point)
		{
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (user == null) return RedirectToAction("Login", "Account");

			Rate Rate = new Rate
			{
				Date = DateTime.Now,
				AppUser = user,
				FurnitureId = id,
				Point = point
			};
			_context.Rates.Add(Rate);
			_context.SaveChanges();
			Furniture furniture = _context.Furnitures.FirstOrDefault(c => c.Id == id);
			List<Rate> rates = _context.Rates.Include(r => r.Furniture).Where(r => r.FurnitureId == id).ToList();
			int pointrate = 0;
			foreach (var item in rates)
			{
				pointrate += item.Point;
			}
			if (rates.Count > 0)
			{
				furniture.AvgPoint = pointrate / rates.Count;
				_context.SaveChanges();
			}
			return Json("Oke");
		}

		public async Task<IActionResult> DeleteRate(int id, int furnitureid)
		{
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
		
			if (!ModelState.IsValid) return RedirectToAction("Detail", "Furniture");
			Furniture furniture = _context.Furnitures.FirstOrDefault(c => c.Id == furnitureid);
			if (User.IsInRole("Admin"))
			{
				Rate rateadmin = _context.Rates.FirstOrDefault(c => c.Id == id);
				_context.Rates.Remove(rateadmin);
				_context.SaveChanges();
				List<Rate> ratesadmin = _context.Rates.Include(r => r.Furniture).Where(r => r.FurnitureId == furnitureid).ToList();
				int pointrateadmin = 0;
				if (ratesadmin.Count == 0)
				{
					furniture.AvgPoint = 0;
				}
				else
				{
					foreach (var item in ratesadmin)
					{
						pointrateadmin += item.Point;
					}
					furniture.AvgPoint = pointrateadmin / ratesadmin.Count;
				}
				_context.SaveChanges();
				return RedirectToAction("Detail", "Furniture", new { id = rateadmin.FurnitureId });
			}
		    else if (!_context.Rates.Any(c => c.Id == id && c.AppUserId == user.Id))
		    {
				return NotFound();
			}
			Rate rate = _context.Rates.FirstOrDefault(c => c.Id == id && c.AppUserId == user.Id);
			_context.Rates.Remove(rate);
			_context.SaveChanges();
			List<Rate> rates = _context.Rates.Include(r => r.Furniture).Where(r => r.FurnitureId == furnitureid).ToList();

			int pointrate = 0;
			if (rates.Count == 0)
			{
				furniture.AvgPoint = 0;
			}
			else
			{
				foreach (var item in rates)
				{
					pointrate += item.Point;
				}
				furniture.AvgPoint = pointrate / rates.Count;
			}
			_context.SaveChanges();
			return RedirectToAction("Detail", "Furniture", new { id = rate.FurnitureId });
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> AddComment(Comment comment)
		{
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (!ModelState.IsValid) return RedirectToAction("Detail", "Furniture", new { id = comment.FurnitureId });
			if (!_context.Furnitures.Any(f => f.Id == comment.FurnitureId)) return NotFound();
			if (comment.Text != null)
			{
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
			
			return RedirectToAction("Detail", "Furniture", new { id = comment.FurnitureId });
		}

		public async Task<IActionResult> DeleteComment(int id)
		{
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (!ModelState.IsValid) return RedirectToAction("Detail", "Furniture");
			if (User.IsInRole("Admin"))
			{
				Comment commentadmin = _context.Comments.FirstOrDefault(c => c.Id == id);
				_context.Comments.Remove(commentadmin);
				_context.SaveChanges();
				return RedirectToAction("Detail", "Furniture", new { id = commentadmin.FurnitureId });
			}
			else if (!_context.Comments.Any(c => c.Id == id && c.AppUserId == user.Id))
			{
				return NotFound();
			}
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
