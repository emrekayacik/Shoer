using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shoer.Models
{
    public class Login
    {
        [DisplayName("Username")]
        [Required(ErrorMessage = "Username can't be empty")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password can't be empty")]
        public string CustomerPassword { get; set; }
    }
}
