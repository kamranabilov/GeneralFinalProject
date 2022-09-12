using FianlProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FianlProject.Models
{
	public class Furniture:BaseEntity
	{
		public string Image { get; set; }
		[Required]
		public string Name { get; set; }
		public string SKU { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }

	}
}
