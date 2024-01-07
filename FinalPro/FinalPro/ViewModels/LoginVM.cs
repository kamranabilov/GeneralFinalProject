using System.ComponentModel.DataAnnotations;

namespace FianlProject.ViewModels
{
	public class LoginVM
	{
		[Required, StringLength(20)]
		public string UserName { get; set; }
		[Required, DataType(DataType.Password)]
		public string Password { get; set; }
		public bool Remember { get; set; }
	}
}
