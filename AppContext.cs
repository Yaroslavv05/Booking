using TimeTracker.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace TimeTracker.Core.Context
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-C8019C9;Initial Catalog=TimeTracker_db;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(key => key.UserId);
        }
    }
}

TrustServerCertificate = True