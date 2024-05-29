using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProiectPAW.Models;

namespace ProiectPAW.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Review>? Reviews { get; set; }
        public DbSet<Provider>? Providers { get; set; }
        public DbSet<ProductImage>? ProductImages { get; set; }
        public DbSet <Category>? Categories { get; set; }
        public DbSet<OrderProduct>? OrderProducts { get; set; }

        public DbSet<UserInfo>? UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call base method

            // Your fluent modeling here
            // For example, if you need to specify configurations for your entities:
            // modelBuilder.Entity<Document>().Property(d => d.Name).IsRequired();
            // modelBuilder.Entity<Grade>().HasMany(g => g.Students).WithOne(s => s.Grade);
            // Add any additional configurations for your entities here
        }
    }
}
