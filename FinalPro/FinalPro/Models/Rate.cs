using FianlProject.Models.Base;
using System;
using System.Collections.Generic;

namespace FianlProject.Models
{
	public class Rate : BaseEntity
	{
		public DateTime Date { get; set; }
		public byte Point { get; set; }
		public Furniture Furniture { get; set; }
		public int FurnitureId { get; set; }
		public AppUser AppUser { get; set; }
		public string AppUserId { get; set; }
	}
}
