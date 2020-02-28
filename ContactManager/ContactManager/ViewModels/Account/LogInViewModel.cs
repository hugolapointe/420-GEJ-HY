using System.ComponentModel.DataAnnotations;

namespace ContactManager.ViewModels.Account {
    public class LogInViewModel {
        [Required]
        [Display(Name = "Username or Email")]
        public string UsernameOrEmail { get; set; }

        [Required]
        [UIHint("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
