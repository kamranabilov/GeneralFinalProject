using System.ComponentModel.DataAnnotations;

namespace FianlProject.ViewModels
{
    public class ForgetPasswordVM
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
