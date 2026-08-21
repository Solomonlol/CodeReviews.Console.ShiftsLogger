using Microsoft.EntityFrameworkCore;
using ShiftLogger.Backend.Entities;

namespace Solomonlol.ShiftLogger
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Shift> Shifts { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shift>()
                .HasOne(u=>u.Employee)
                .WithMany(s=>s.Shifts)
                .HasForeignKey(s=>s.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmployeeNumber)
                .IsUnique();
        }
    }
}
