using FianlProject.DAL;
using FianlProject.Models;
using FianlProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
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
		[Authorize(Roles = "Member")]
		public async  Task<IActionResult> Index()
        {
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (user == null) return RedirectToAction("Login", "Account");
			return View();
        }

		public IActionResult GetPartial()
		{
			return PartialView("_basketPartial");
		}

		[HttpPost]
		public async Task<IActionResult> increase(int Id)
		{
			int quantity = 0;
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
			BasketItem basket = _context.BasketItems.Include(m => m.Furniture).FirstOrDefault(m => m.FurnitureId == Id && m.AppUserId == user.Id);
			basket.Quantity++;
			_context.SaveChanges();
			decimal TotalPrice = 0;
			decimal Price = basket.Quantity * basket.Price;
			quantity = basket.Quantity;
			List<BasketItem> basketItems = _context.BasketItems.Include(m => m.AppUser).Include(m => m.Furniture).Where(m => m.AppUserId == user.Id).ToList();
			foreach (BasketItem item in basketItems)
			{
				Furniture furniture = _context.Furnitures.Include(m => m.Categories).FirstOrDefault(m => m.Id == item.FurnitureId);

				BasketItemVM basketItemVM = new BasketItemVM
				{
					Furniture = furniture,
					Quantity = item.Quantity
				};
				basketItemVM.Price = furniture.Price;

				TotalPrice += basketItemVM.Price * basketItemVM.Quantity;

			}

			return Json(new { totalPrice = TotalPrice, Price, quantity});
		}
		public async Task<IActionResult> decrease(int Id)
		{
			AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
			BasketItem basket = _context.BasketItems.Include(m => m.Furniture).FirstOrDefault(m => m.FurnitureId == Id && m.AppUserId == user.Id);
			int quantity = 0;
			if (basket.Quantity == 1)
			{
				basket.Quantity = 1;
			}
			else
			{
				basket.Quantity--;
			}
			_context.SaveChanges();
			decimal TotalPrice = 0;
			decimal Price = basket.Quantity * basket.Price;
			List<BasketItem> basketItems = _context.BasketItems.Include(m => m.AppUser).Include(m => m.Furniture).Where(b => b.AppUserId == user.Id).ToList();
			quantity = basket.Quantity;
			foreach (BasketItem item in basketItems)
			{
				Furniture furniture = _context.Furnitures.FirstOrDefault(m => m.Id == item.FurnitureId);

				BasketItemVM basketItemVM = new BasketItemVM
				{
					Furniture = furniture,
					Quantity = item.Quantity
				};
				basketItemVM.Price = furniture.Price;
				TotalPrice += basketItemVM.Price * basketItemVM.Quantity;

			}

			return Json(new { totalPrice = TotalPrice, Price, quantity });
		}
		public async Task<IActionResult> AddBasket(int id)
		{
			Furniture furniture = _context.Furnitures.Include(m => m.Furnitureimages).Include(m => m.Categories).FirstOrDefault(m => m.Id == id);
			if (furniture == null) return View("This is error msg");

			if (User.Identity.IsAuthenticated && User.IsInRole("Member"))
			{
				AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

				BasketItem basketItem = _context.BasketItems.FirstOrDefault(m => m.FurnitureId == furniture.Id && m.AppUserId == user.Id);
				if (basketItem == null)
				{
					basketItem = new BasketItem
					{
						AppUserId = user.Id,
						Price = furniture.Price,
						FurnitureId = furniture.Id,
						Quantity = 1
					};
					_context.BasketItems.Add(basketItem);
				}
				else
				{
					basketItem.Quantity++;
				}
				_context.SaveChanges();
				//TempData["name"] = "Product added to cart successfully";
				return PartialView("_basketPartial");
			}
			else
			{
				string basket = HttpContext.Request.Cookies["Basket"];

				if (basket == null)
				{
					List<BasketCookieItemVM> basketCookieItems = new List<BasketCookieItemVM>();

					basketCookieItems.Add(new BasketCookieItemVM
					{
						Id = furniture.Id,
						Quantity = 1
					});

					string basketStr = JsonConvert.SerializeObject(basketCookieItems);


					HttpContext.Response.Cookies.Append("Basket", basketStr);
					return PartialView("_basketPartial");
					//return RedirectToAction("Index", "Home");

				}
				else
				{
					List<BasketCookieItemVM> basketCookieItems = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(basket);

					BasketCookieItemVM cookieItem = basketCookieItems.FirstOrDefault(c => c.Id == furniture.Id);

					if (cookieItem == null)
					{
						cookieItem = new BasketCookieItemVM
						{
							Id = furniture.Id,
							Quantity = 1
						};
						basketCookieItems.Add(cookieItem);
					}
					else
					{
						cookieItem.Quantity++;
					}

					string basketStr = JsonConvert.SerializeObject(basketCookieItems);

					HttpContext.Response.Cookies.Append("Basket", basketStr);
					return PartialView("_basketPartial");
					//return RedirectToAction("Index", "Home");

				}
			}
		}

		public async Task<IActionResult> DeleteBasketitem(int id)
		{
			if (User.Identity.IsAuthenticated)
			{
				AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
				List<BasketItem> basketItems = _context.BasketItems.Where(m => m.FurnitureId == id && m.AppUserId == user.Id).ToList();
				foreach (var item in basketItems)
				{
					_context.BasketItems.Remove(item);
				}
			}
			else
			{
				string basket = HttpContext.Request.Cookies["Basket"];

				List<BasketCookieItemVM> basketCookieItems = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(basket);

				BasketCookieItemVM cookieItem = basketCookieItems.FirstOrDefault(c => c.Id == id);


				basketCookieItems.Remove(cookieItem);

				string basketStr = JsonConvert.SerializeObject(basketCookieItems);

				HttpContext.Response.Cookies.Append("Basket", basketStr);

			}
			_context.SaveChanges();
			//TempData["name"] = "Product added to cart successfully";
			return PartialView("_basketPartial");
		}
		public async Task<IActionResult> removeCartItem(int Id)
		{
			if (User.Identity.IsAuthenticated)
			{
				AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

				List<BasketItem> basketItems = _context.BasketItems.Where(m => m.FurnitureId == Id && m.AppUserId == user.Id).ToList();
				if (basketItems == null) return Json(new { status = 404 });
				foreach (var item in basketItems)
				{
					_context.BasketItems.Remove(item);
				}
			}

			_context.SaveChanges();


			return Json(new { status = 200 });
		}

		//public IActionResult Basket()
		//{
		//	HttpContext.Response.Cookies.Append("basket", "test");
		//	return Json(HttpContext.Request.Cookies["Basket"]);
		//}

		//public async Task<IActionResult> AddBasket(int? id)
		//{
		//	Furniture furniture = await _context.Furnitures.FirstOrDefaultAsync(c => c.Id == id);
		//	if (id == null || id == 0) return NotFound();

		//	if (User.Identity.IsAuthenticated && User.IsInRole("Member"))
		//	{
		//		AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
		//		if (user == null) return NotFound();
		//		BasketItem existed = await _context.BasketItems
		//			.FirstOrDefaultAsync(b => b.AppUserId == user.Id && b.FurnitureId == furniture.Id);
		//		if (existed == null)
		//		{
		//			existed = new BasketItem
		//			{
		//				Furniture = furniture,
		//				AppUser = user,
		//				Quantity = 1,
		//				Price = furniture.Price
		//			};
		//			_context.BasketItems.Add(existed);
		//		}
		//		else
		//		{
		//			existed.Quantity++;
		//		}
		//		await _context.SaveChangesAsync();
		//	}
		//	else
		//	{
		//		if (furniture == null) return NotFound();
		//		string BasketStr = HttpContext.Request.Cookies["Basket"];

		//		BasketVM basket;
		//		if (string.IsNullOrEmpty(BasketStr))
		//		{
		//			basket = new BasketVM();
		//			BasketCookieItemVM cookieItemVM = new BasketCookieItemVM
		//			{
		//				Id = furniture.Id,
		//				Quantity = 1
		//			};
		//			basket.BasketCookieItemVMs = new List<BasketCookieItemVM>();
		//			basket.BasketCookieItemVMs.Add(cookieItemVM);
		//			basket.TotalPrice = furniture.Price;
		//		}
		//		else
		//		{
		//			basket = JsonConvert.DeserializeObject<BasketVM>(BasketStr);
		//			BasketCookieItemVM existed = basket.BasketCookieItemVMs.FirstOrDefault(b => b.Id == id);
		//			if (existed == null)
		//			{
		//				BasketCookieItemVM cookieItemVM = new BasketCookieItemVM
		//				{
		//					Id = furniture.Id,
		//					Quantity = 1
		//				};
		//				basket.BasketCookieItemVMs.Add(cookieItemVM);
		//				basket.TotalPrice += furniture.Price;
		//			}
		//			else
		//			{
		//				basket.TotalPrice += furniture.Price;
		//				existed.Quantity++;
		//			}
		//		}
		//		BasketStr = JsonConvert.SerializeObject(basket);

		//		HttpContext.Response.Cookies.Append("Basket", BasketStr);
		//	}
		//	//return Json("working");
		//	//return Redirect(Request.Headers["Referer"].ToString());

		//	return RedirectToAction("Index", "Cart");
		//}

		//public IActionResult ShowBasket()
		//{
		//	if (HttpContext.Request.Cookies["Basket"] == null) return NotFound();
		//	BasketVM basket = JsonConvert.DeserializeObject<BasketVM>(HttpContext.Request.Cookies["Basket"]);
		//	return Json(basket);
		//}

		//public IActionResult Plus(int? id)
		//{
		//	if (id == 0 || id == null) return NotFound();
		//	string basketStr = HttpContext.Request.Cookies["Basket"];
		//	Furniture furniture = _context.Furnitures.FirstOrDefault(c => c.Id == id);
		//	BasketVM basket;
		//	if (basketStr == null)
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

		//		basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);

		//		BasketCookieItemVM cookieItemVM = basket.BasketCookieItemVMs.SingleOrDefault(c => c != null && c.Id == id);
		//		if (cookieItemVM == null)
		//		{
		//			BasketCookieItemVM basketCookieItemVM = new BasketCookieItemVM
		//			{
		//				Id = furniture.Id,
		//				Quantity = 1

		//			};
		//			basket.BasketCookieItemVMs.Add(basketCookieItemVM);
		//			basket.TotalPrice += furniture.Price;
		//		}
		//		else
		//		{
		//			basket.TotalPrice += furniture.Price;
		//			cookieItemVM.Quantity++;
		//		}
		//	}
		//	basketStr = JsonConvert.SerializeObject(basket);
		//	HttpContext.Response.Cookies.Append("Basket", basketStr);
		//	return Redirect(Request.Headers["Referer"].ToString());
		//}

		//public IActionResult Minus(int? id)
		//{
		//	if (id == 0 || id == null) return NotFound();
		//	string basketStr = HttpContext.Request.Cookies["Basket"];
		//	Furniture furniture = _context.Furnitures.FirstOrDefault(c => c.Id == id);
		//	BasketVM basket;
		//	if (basketStr == null)
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
		//		basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
		//		BasketCookieItemVM cookieItemVM = basket.BasketCookieItemVMs.SingleOrDefault(c => c != null && c.Id == id);
		//		if (cookieItemVM == null)
		//		{
		//			BasketCookieItemVM basketCookieItemVM = new BasketCookieItemVM
		//			{
		//				Id = furniture.Id,
		//				Quantity = 1
		//			};
		//			basket.BasketCookieItemVMs.Add(basketCookieItemVM);
		//			basket.TotalPrice += furniture.Price;
		//		}
		//		else
		//		{
		//			if (cookieItemVM.Quantity > 1)
		//			{
		//				basket.TotalPrice -= furniture.Price;
		//				cookieItemVM.Quantity--;
		//			}
		//		}
		//	}
		//	basketStr = JsonConvert.SerializeObject(basket);
		//	HttpContext.Response.Cookies.Append("Basket", basketStr);
		//	return RedirectToAction("Index", "Cart");
		//	//return Redirect(Request.Headers["Referer"].ToString());
		//}

		//public async Task<IActionResult> RemoveFromClothes(int? id)
		//{
		//	if (id == null || id == 0) NotFound();
		//	Furniture furniture = await _context.Furnitures.FirstOrDefaultAsync(c => c.Id == id);
		//	if (furniture == null) NotFound();
		//	string basketStr = HttpContext.Request.Cookies["Basket"];
		//	if (string.IsNullOrEmpty(basketStr)) NotFound();
		//	BasketVM basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
		//	BasketCookieItemVM existed = basket.BasketCookieItemVMs.FirstOrDefault(c => c.Id == id);
		//	basket.BasketCookieItemVMs.Remove(existed);
		//	basket.TotalPrice -= (existed.Quantity * furniture.Price);
		//	basketStr = JsonConvert.SerializeObject(basket);
		//	HttpContext.Response.Cookies.Append("Basket", basketStr);
		//	return RedirectToAction("Index", "Index");
		//}
	}
}
