using System.ComponentModel.DataAnnotations;

namespace ICExample.Models.Account {
    public class LoginModel {
        [Required]
        [Display(Name = "Username or Email")]
        public string UsernameOrEmail { get; set; }

        [Required]
        [UIHint("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
