using FianlProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FianlProject.Models
{
	public class Contact:BaseEntity
	{
		[Required, MaxLength(20)]
		public string Name { get; set; }
		[Required, MaxLength(40), DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required, MaxLength(30)]
		public string Subject { get; set; }
		[Required, MaxLength(500)]
		public string Description { get; set; }
	}
}
