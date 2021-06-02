using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shoer.Models
{
    public class Register
    {
        [DisplayName("Username")]
        [MaxLength(25, ErrorMessage = "Max Length of Username must be 25")]
        [MinLength(7, ErrorMessage = "Min Length of Username must be 7")]
        [Required(ErrorMessage = "Username can't be empty")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        [MaxLength(16, ErrorMessage = "Max Length of Password must be 18")]
        [MinLength(9, ErrorMessage = "Min Length of Password must be 9")]
        [Required(ErrorMessage = "Password can't be empty")]
        public string CustomerPassword { get; set; }
        [Required(ErrorMessage = "First Name can't be empty")]
        [DisplayName("First Name")]
        public string Firstname { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name can't be empty")]
        public string LastName { get; set; }
    }
}
