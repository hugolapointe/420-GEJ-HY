using Microsoft.EntityFrameworkCore;

namespace VCExample.Models {
    public class ToDoContext : DbContext {

        public DbSet<ToDo> ToDo { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            for(int i = 0; i < 9; i++) {
                modelBuilder.Entity<ToDo>().HasData(
                   new ToDo {
                       Id = i + 1,
                       IsDone = i % 3 == 0,
                       Name = $"Task #{i + 1}",
                       Priority = i % 5 + 1
                   });
            }
        }
    }
}