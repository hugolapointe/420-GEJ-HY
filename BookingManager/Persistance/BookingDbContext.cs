using BookingManager.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace BookingManager.Persistance {
    public class BookingDbContext : DbContext {
        public DbSet<Appointment> Appointments { get; set; }

        public BookingDbContext(DbContextOptions options) : base(options) { }
    }
}
