using FianlProject.Models;

namespace FianlProject.ViewModels
{
    public class BasketItemVM
    {
		public Furniture Furniture { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
}
