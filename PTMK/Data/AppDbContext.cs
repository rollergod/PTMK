using Microsoft.EntityFrameworkCore;
using PTMK.Entities;
using PTMK.Entities.Enum;

namespace PTMK.Data
{
    public sealed class AppDbContext : DbContext
    {
        private readonly string connectionString = null;
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    FullName = "Test Test Testovich",
                    Date = new DateOnly(2000, 5, 12),
                    Gender = Gender.Male,
                }
            );
        }
    }
}
