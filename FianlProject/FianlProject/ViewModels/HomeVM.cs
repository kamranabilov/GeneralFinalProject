using FianlProject.Models;
using System.Collections.Generic;

namespace FianlProject.ViewModels
{
    public class HomeVM
    {
		public List<Slider> Sliders { get; set; }
		public List<Furniture> Furnitures { get; set; }
		public List<Category> Categories { get; set; }
		public List<Contact> Contacts { get; set; }
		public List<About> Abouts { get; set; }
	}
}
