using FianlProject.Models.Base;
using System.Collections.Generic;

namespace FianlProject.Models
{
    public class FurnitureDescription:BaseEntity
    {
        public string Image { get; set; }
        public List<Furniture> Furnitures { get; set; }
    }
}
