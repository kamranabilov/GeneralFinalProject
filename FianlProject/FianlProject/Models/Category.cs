using FianlProject.Models.Base;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FianlProject.Models
{
	public class Category:BaseEntity
	{
		public string Image { get; set; }
		public string Name { get; set; }
		public List<Furniture> Furnitures { get; set; }
		[NotMapped]
		public IFormFile Photo { get; set; }
	}
}
