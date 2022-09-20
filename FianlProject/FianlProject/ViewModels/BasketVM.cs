using System.Collections.Generic;

namespace FianlProject.ViewModels
{
    public class BasketVM
    {
		public List<BasketCookieItemVM> BasketCookieItemVMs { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
