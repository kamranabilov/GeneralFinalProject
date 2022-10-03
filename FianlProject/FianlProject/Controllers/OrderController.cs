using FianlProject.DAL;
using FianlProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using FianlProject.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace FianlProject.Controllers
{
	[Authorize(Roles = "Member")]
	public class OrderController : Controller
    {
		private readonly UserManager<AppUser> _userManager;
		private readonly AppDbContext _context;

		public OrderController(UserManager<AppUser> userManager, AppDbContext context)
        {
			_userManager = userManager;
			_context = context;
		}
        //public IActionResult Checkout()
        //{
        //    return View();
        //}

		public async Task<IActionResult> ViewCart()
		{
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (user == null) return RedirectToAction("Login", "Account");

			OrderVM model = new OrderVM
			{

				FirstName = user.FirstName,
				LastName = user.LastName,
				Username = user.UserName,
				Email = user.Email,
				BasketItems = _context.BasketItems.Include(m => m.Furniture).Where(m => m.AppUserId == user.Id).ToList(),

			};
			return View(model);

		}
		public async Task<IActionResult> Checkout()
		{
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

			OrderVM model = new OrderVM
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Username = user.UserName,
				Email = user.Email,
				BasketItems = _context.BasketItems.Include(m => m.Furniture).Where(m => m.AppUserId == user.Id).ToList()

			};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Checkout(OrderVM orderVM)
		{
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
			OrderVM model = new OrderVM
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Username = user.UserName,
				Email = user.Email,
				BasketItems = _context.BasketItems.Include(m => m.Furniture).Where(m => m.AppUserId == user.Id).ToList()
			};
			if (!ModelState.IsValid) return View(model);

			TempData["Succeeded"] = false;

			if (model.BasketItems.Count == 0) return RedirectToAction("index", "home");
			Order order = new Order
			{
				Country = orderVM.Country,
				City = orderVM.City,
				Address = orderVM.Address,
				PhoneNumber = orderVM.PhoneNumber,
				TotalPrice = 0,
				Date = DateTime.Now,
				AppUserId = user.Id
			};

			foreach (BasketItem item in model.BasketItems)
			{
				order.TotalPrice += item.Furniture.Price * item.Quantity;
				OrderItem orderItem = new OrderItem
				{
					Name = item.Furniture.Name,
					Price = item.Furniture.Price,
					Quantity = item.Quantity,
					AppUserId = user.Id,
					FurnitureId = item.Furniture.Id,
					Order = order
				};
				_context.OrderItems.Add(orderItem);
			}
			_context.BasketItems.RemoveRange(model.BasketItems);
			_context.Orders.Add(order);
			_context.SaveChanges();
			TempData["Succeeded"] = true;

			return RedirectToAction("index", "home");
		}
	}
}
