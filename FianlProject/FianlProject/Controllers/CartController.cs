using FianlProject.DAL;
using FianlProject.Models;
using FianlProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FianlProject.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
		private readonly UserManager<AppUser> _userManager;

		public CartController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
			_userManager = userManager;
		}
        public IActionResult Index()
        {
            return View();
        }

		public async Task<IActionResult> AddBasket(int? id)
		{
			Furniture furniture = await _context.Furnitures.FirstOrDefaultAsync(c => c.Id == id);
			if (id == null || id == 0) return NotFound();

			//if (User.Identity.IsAuthenticated && User.IsInRole("Member"))
			//{
			//AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
			//	if (user == null) return NotFound();
			//	BasketItem existed = await _context.BasketItems
			//		.FirstOrDefaultAsync(b => b.AppUserId == user.Id && b.FurnitureId == furniture.Id);	
			//	if (existed == null)
			//	{
			//		existed = new BasketItem
			//		{
			//			Furniture = furniture,
			//			AppUser = user,
			//			Quantity = 1,
			//			Price = furniture.Price
			//		};
			//		_context.BasketItems.Add(existed);
			//	}
			//	else
			//	{
			//		existed.Quantity++;
			//	}
			//	await _context.SaveChangesAsync();
			//}
			//else
			//{
			//	if (furniture == null) return NotFound();
			//	string BasketStr = HttpContext.Request.Cookies["Basket"];

			//	BasketVM basket;
			//	if (string.IsNullOrEmpty(BasketStr))
			//	{
			//		basket = new BasketVM();
			//		BasketCookieItemVM cookieItemVM = new BasketCookieItemVM
			//		{
			//			Id = furniture.Id,
			//			Quantity = 1
			//		};
			//		basket.BasketCookieItemVMs = new List<BasketCookieItemVM>();
			//		basket.BasketCookieItemVMs.Add(cookieItemVM);
			//		basket.TotalPrice = furniture.Price;
			//	}
			//	else
			//	{
			//		basket = JsonConvert.DeserializeObject<BasketVM>(BasketStr);
			//		BasketCookieItemVM existed = basket.BasketCookieItemVMs.FirstOrDefault(b => b.Id == id);
			//		if (existed == null)
			//		{
			//			BasketCookieItemVM cookieItemVM = new BasketCookieItemVM
			//			{
			//				Id = furniture.Id,
			//				Quantity = 1
			//			};
			//			basket.BasketCookieItemVMs.Add(cookieItemVM);
			//			basket.TotalPrice += furniture.Price;
			//		}
			//		else
			//		{
			//			basket.TotalPrice += furniture.Price;
			//			existed.Quantity++;
			//		}
			//	}
			//	BasketStr = JsonConvert.SerializeObject(basket);

			//	HttpContext.Response.Cookies.Append("Basket", BasketStr);
			//}
			//return Json("working");
			//return Redirect(Request.Headers["Referer"].ToString());

			return RedirectToAction("cart", "index");
		}

		public IActionResult ShowBasket()
		{
			if (HttpContext.Request.Cookies["Basket"] == null) return NotFound();
			BasketVM basket = JsonConvert.DeserializeObject<BasketVM>(HttpContext.Request.Cookies["Basket"]);
			return Json(basket);
		}

		public IActionResult Plus(int? id)
		{
			if (id == 0 || id == null) return NotFound();
			string basketStr = HttpContext.Request.Cookies["Basket"];
			Furniture furniture = _context.Furnitures.FirstOrDefault(c => c.Id == id);
			BasketVM basket;
			if (basketStr == null)
			{
				basket = new BasketVM();
				BasketCookieItemVM cookieItemVM = new BasketCookieItemVM
				{
					Id = furniture.Id,
					Quantity = 1
				};
				basket.BasketCookieItemVMs = new List<BasketCookieItemVM>();
				basket.BasketCookieItemVMs.Add(cookieItemVM);
				basket.TotalPrice = furniture.Price;
			}
			else
			{

				basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);

				BasketCookieItemVM cookieItemVM = basket.BasketCookieItemVMs.SingleOrDefault(c => c != null && c.Id == id);
				if (cookieItemVM == null)
				{
					BasketCookieItemVM basketCookieItemVM = new BasketCookieItemVM
					{
						Id = furniture.Id,
						Quantity = 1

					};
					basket.BasketCookieItemVMs.Add(basketCookieItemVM);
					basket.TotalPrice += furniture.Price;
				}
				else
				{
					basket.TotalPrice += furniture.Price;
					cookieItemVM.Quantity++;
				}
			}
			basketStr = JsonConvert.SerializeObject(basket);
			HttpContext.Response.Cookies.Append("Basket", basketStr);
			return Redirect(Request.Headers["Referer"].ToString());
		}

		public IActionResult Minus(int? id)
		{
			if (id == 0 || id == null) return NotFound();
			string basketStr = HttpContext.Request.Cookies["Basket"];
			Furniture furniture = _context.Furnitures.FirstOrDefault(c => c.Id == id);
			BasketVM basket;
			if (basketStr == null)
			{
				basket = new BasketVM();
				BasketCookieItemVM cookieItemVM = new BasketCookieItemVM
				{
					Id = furniture.Id,
					Quantity = 1
				};
				basket.BasketCookieItemVMs = new List<BasketCookieItemVM>();
				basket.BasketCookieItemVMs.Add(cookieItemVM);
				basket.TotalPrice = furniture.Price;
			}
			else
			{
				basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
				BasketCookieItemVM cookieItemVM = basket.BasketCookieItemVMs.SingleOrDefault(c => c != null && c.Id == id);
				if (cookieItemVM == null)
				{
					BasketCookieItemVM basketCookieItemVM = new BasketCookieItemVM
					{
						Id = furniture.Id,
						Quantity = 1
					};
					basket.BasketCookieItemVMs.Add(basketCookieItemVM);
					basket.TotalPrice += furniture.Price;
				}
				else
				{
					if (cookieItemVM.Quantity > 1)
					{
						basket.TotalPrice -= furniture.Price;
						cookieItemVM.Quantity--;
					}
				}
			}
			basketStr = JsonConvert.SerializeObject(basket);
			HttpContext.Response.Cookies.Append("Basket", basketStr);
			return RedirectToAction("cart", "index");
			//return Redirect(Request.Headers["Referer"].ToString());
		}

		public async Task<IActionResult> RemoveFromClothes(int? id)
		{
			if (id == null || id == 0) NotFound();
			Furniture furniture = await _context.Furnitures.FirstOrDefaultAsync(c => c.Id == id);
			if (furniture == null) NotFound();
			string basketStr = HttpContext.Request.Cookies["Basket"];
			if (string.IsNullOrEmpty(basketStr)) NotFound();
			BasketVM basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
			BasketCookieItemVM existed = basket.BasketCookieItemVMs.FirstOrDefault(c => c.Id == id);
			basket.BasketCookieItemVMs.Remove(existed);
			basket.TotalPrice -= (existed.Quantity * furniture.Price);
			basketStr = JsonConvert.SerializeObject(basket);
			HttpContext.Response.Cookies.Append("Basket", basketStr);
			return RedirectToAction("cart", "index");
		}
	}
}
