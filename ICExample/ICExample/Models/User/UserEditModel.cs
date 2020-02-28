using System.ComponentModel.DataAnnotations;

namespace ICExample.Models.User {
    public class UserEditModel {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [EmailAddress]
        [UIHint("email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        
        [Required]
        [UIHint("password")]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }
        
        [UIHint("password")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        
        [UIHint("password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirmation")]
        [Compare(nameof(NewPassword), ErrorMessage = "The passwords must matched.")]
        public string PasswordConfirmation { get; set; }
    }
}
