using FianlProject.Models.Base;

namespace FianlProject.Models
{
	public class Furnitureimage:BaseEntity
	{
		public string Name { get; set; }
		public string Alternative { get; set; }
		public bool IsMain { get; set; }
		public int FurnitureId { get; set; }
		public Furniture Furniture { get; set; }
	}
}
