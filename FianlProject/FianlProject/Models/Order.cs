using FianlProject.Models.Base;
using System.Collections.Generic;
using System;

namespace FianlProject.Models
{
    public class Order:BaseEntity
    {
		public DateTime Date { get; set; }
		public decimal Price { get; set; }
		public decimal TotalPrice { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Address { get; set; }
		public int PhoneNumber { get; set; }
		public bool Status { get; set; }
		public List<BasketItem> BasketItems { get; set; }
		public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }
	}
}
