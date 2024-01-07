using System.Collections.Generic;

namespace FianlProject.ViewModels
{
    public class BasketVM
    {
		public List<BasketItemVM> BasketItems { get; set; }
		public decimal TotalPrice { get; set; }
		public int Count { get; set; }
	}
}
