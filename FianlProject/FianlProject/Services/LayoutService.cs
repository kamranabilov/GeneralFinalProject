using FianlProject.DAL;
using FianlProject.Models;
using FianlProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using static System.Net.WebRequestMethods;

namespace FianlProject.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
		private readonly IHttpContextAccessor _http;

		public LayoutService(AppDbContext context, IHttpContextAccessor http)
        {
            _context = context;
			_http = http;
		}
        public List<Setting> getSettings()
        {
            List<Setting> settings = _context.Settings.ToList();
            return settings;
        }

		public List<Category> GetCategories()
		{
			List<Category> categories = _context.Categories.ToList();
			if (!(categories.Count > 0))
			{
				return null;
			}
			return categories;
		}

		public LayoutBasketVM GetBasket()
		{
			string basketStr = _http.HttpContext.Request.Cookies["Basket"];
			if (!string.IsNullOrEmpty(basketStr))
			{
				BasketVM basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
				LayoutBasketVM layoutBasket = new LayoutBasketVM();
				layoutBasket.BasketItemVMs = new List<BasketItemVM>();
				foreach (BasketCookieItemVM cookie in basket.BasketCookieItemVMs)
				{
					Furniture existed = _context.Furnitures.Include(c => c.Furnitureimages)
						.FirstOrDefault(c => c.Id == cookie.Id);
					if (existed == null)
					{
						basket.BasketCookieItemVMs.Remove(cookie);
						continue;
					}
					BasketItemVM basketItem = new BasketItemVM
					{
						Furniture = existed,
						Quantity = cookie.Quantity
					};
					layoutBasket.BasketItemVMs.Add(basketItem);
				}
				layoutBasket.TotalPrice = basket.TotalPrice;
				return layoutBasket;
			}
			return null;
		}
	}
}
