using System;

namespace ContactManager.Models {
    public class ContactModel {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Guid OwnerId { get; set; }
        public UserModel Owner { get; set; }
    }
}
