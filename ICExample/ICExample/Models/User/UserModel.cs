using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ICExample.Models.User {
    public class UserModel : IdentityUser {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}

