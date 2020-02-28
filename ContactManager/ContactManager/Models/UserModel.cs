using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ContactManager.Models {
    public class UserModel : IdentityUser<Guid> {

        public IEnumerable<ContactModel> Contacts { get; set; }
    }
}
