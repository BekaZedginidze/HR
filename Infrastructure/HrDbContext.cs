using System.Reflection.Emit;
using HR.Entity;
using Microsoft.EntityFrameworkCore;


namespace HR.Infrastructure
{
    public class HrDbContext : DbContext
    {

        public HrDbContext(DbContextOptions<HrDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public DbSet<Registration> Registration { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                   .HasOne(X => X.Gender)
                   .WithMany(x => x.Customers)
                   .HasForeignKey(x => x.GenderId).IsRequired();

            base.OnModelCreating(modelBuilder);
            new CustomerMap(modelBuilder.Entity<Customer>());
        }

    }
}
