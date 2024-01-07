using FianlProject.Models.Base;

namespace FianlProject.Models
{
    public class OrderItem:BaseEntity
    {
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public int? FurnitureId { get; set; }
		public Furniture Furniture { get; set; }
		public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		public int OrderId { get; set; }
		public Order Order { get; set; }
	}
}
