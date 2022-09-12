using FianlProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FianlProject.Models
{
    public class Slider:BaseEntity
    {
        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public string Discount { get; set; }
        [Required]
        public string ButtonUrl { get; set; }
        [Required]
        public byte Order { get; set; }
    }
}
