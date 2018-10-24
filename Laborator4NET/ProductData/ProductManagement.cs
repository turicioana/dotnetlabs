using Microsoft.EntityFrameworkCore;

namespace ProductData
{
    public class ProductManagement : DbContext
    {
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Product> Products { set; get; }

        public ProductManagement()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-SP588FT\\DATABASESQL;Database=ProductManagement;User ID=sa;Password=1234;");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Adress)
                .IsRequired()
                .HasMaxLength(300);

            modelBuilder.Entity<Customer>()
                .Property(c => c.PhoneNumber)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .IsRequired();
        }
    }
}
