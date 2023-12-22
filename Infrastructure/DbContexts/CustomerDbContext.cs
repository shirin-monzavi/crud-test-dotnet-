using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(b =>
            {
                b.HasKey(o => o.Id);
                b.Property(o => o.FirstName);
                b.HasIndex(o => new { o.FirstName, o.LastName, o.DateOfBirth }).IsUnique(true);

                b.Property(o => o.LastName);
                b.Property(o => o.BankAccountNumber);
                b.Property(o => o.IsDeleted);

                b.Property(o => o.Email);
                b.HasIndex(e => e.Email).IsUnique(true);

                b.Property(o => o.PhoneNumber).HasMaxLength(20).IsUnicode(false);
                b.Property(o => o.DateOfBirth);
            });
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
