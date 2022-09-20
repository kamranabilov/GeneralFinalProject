using FianlProject.Models.Base;
using System.Collections.Generic;

namespace FianlProject.Models
{
    public class AppUser:BaseEntity
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public List<BasketItem> BasketItems { get; set; }
		public List<Order> Order { get; set; }
	}
}
