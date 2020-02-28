using System.ComponentModel.DataAnnotations;

namespace ICExample.Models.User {
    public class UserCreateModel {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        [UIHint("email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [UIHint("password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirmation")]
        [Compare(nameof(Password), ErrorMessage = "The passwords must matched.")]
        public string PasswordConfirmation { get; set; }
    }
}
