using FianlProject.Models.Base;

namespace FianlProject.Models
{
    public class Wishlistitem:BaseEntity
    {
		public int FurnitureId { get; set; }
		public Furniture Furniture { get; set; }
		public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		public int Count { get; set; }
	}
}
