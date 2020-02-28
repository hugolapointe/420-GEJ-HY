using ContactManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactManager.Data {
    public class AppDbContext : IdentityDbContext<UserModel, 
                                IdentityRole<Guid>, Guid> {
        public DbSet<ContactModel> Contacts { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<ContactModel>()
                .HasOne(c => c.Owner)
                .WithMany(o => o.Contacts)
                .HasForeignKey(c => c.OwnerId);

            base.OnModelCreating(builder);

            var hasher = new PasswordHasher<UserModel>();

            var hlapointe = new UserModel {
                Id = Guid.NewGuid(),
                UserName = "hlapointe",
                NormalizedUserName = "hlapointe",
                Email = "hlapointe@cegepsth.qc.ca",
                NormalizedEmail = "hlapointe@cegepsth.qc.ca",
                EmailConfirmed = true,
                SecurityStamp = String.Empty
            };
            hlapointe.PasswordHash = hasher.HashPassword(hlapointe, "test");

            var hstlouis = new UserModel {
                Id = Guid.NewGuid(),
                UserName = "hstlouis",
                NormalizedUserName = "hstlouis",
                Email = "hstlouis@cegepsth.qc.ca",
                NormalizedEmail = "hstlouis@cegepsth.qc.ca",
                EmailConfirmed = true,
                SecurityStamp = String.Empty
            };
            hlapointe.PasswordHash = hasher.HashPassword(hlapointe, "test");

            builder.Entity<UserModel>().HasData(hlapointe, hstlouis);

            var mlalancette = new ContactModel {
                Id = Guid.NewGuid(),
                FirstName = "Martin",
                LastName = "Lalancette",
                Email = "mlalancette@cegepsth.qc.ca",
                OwnerId = hlapointe.Id
            };

            var aouellet = new ContactModel {
                Id = Guid.NewGuid(),
                FirstName = "Arthur",
                LastName = "Ouellet",
                Email = "aouellet@cegepsth.qc.ca",
                OwnerId = hlapointe.Id
            };
            var spouliot = new ContactModel {
                Id = Guid.NewGuid(),
                FirstName = "Sébstien",
                LastName = "Pouliot",
                Email = "spoulit@cegepsth.qc.ca",
                OwnerId = hstlouis.Id
            };
            builder.Entity<ContactModel>().HasData(mlalancette, aouellet, spouliot);
        }
    }
}
