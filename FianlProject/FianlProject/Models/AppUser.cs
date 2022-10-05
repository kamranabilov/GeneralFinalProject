﻿using FianlProject.Models.Base;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FianlProject.Models
{
    public class AppUser:IdentityUser
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public bool? Admin { get; set; }
		public List<BasketItem> BasketItems { get; set; }
		public List<Order> Orders { get; set; }
	}
}
