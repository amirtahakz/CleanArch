using CleanArch.Domain.OrderAgg;
using CleanArch.Domain.ProductAgg;
using CleanArch.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Persistent.Ef
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {  }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().OwnsOne(b => b.Price, option =>
            {
                option.Property(b => b.Value)
                 .HasColumnName("RialPrice");
            });
            modelBuilder.Entity<Product>().OwnsOne(b => b.Money);
            modelBuilder.Entity<User>().OwnsOne(b => b.PhoneNumber);

            base.OnModelCreating(modelBuilder);
        }
    }

}
