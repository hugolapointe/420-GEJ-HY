using System.ComponentModel.DataAnnotations;

namespace ContactManager.ViewModels.Contact {
    public class ContactDetailsViewModel {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [UIHint("email")]
        public string Email { get; set; }
    }
}
