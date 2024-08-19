using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppToDoList.Models.VMs
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Full name is required.")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage ="Password field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Password Again")]
        [Compare("Password", ErrorMessage ="Password is not match.")]
        [DataType(dataType:DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
