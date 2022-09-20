using System.Collections.Generic;

namespace FianlProject.ViewModels
{
    public class LayoutBasketVM
    {
		public List<BasketItemVM> BasketItemVMs { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
