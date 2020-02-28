using ICExample.Models.Role;
using ICExample.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ICExample.Models {
    public class AppDbContext : IdentityDbContext<UserModel, RoleModel, string> {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}

