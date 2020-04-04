using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Shoes_Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes_Store.Data.EF
{
    public class ShoeserDbContext : DbContext
    {
        public ShoeserDbContext(DbContextOptions<ShoeserDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding data
            modelBuilder.Entity<Account>().HasData(new Account() { 
                Id = Guid.NewGuid(),
                Username ="sa",
                Password = "123",
                Role = Enum.Role.Admin,
            });
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
