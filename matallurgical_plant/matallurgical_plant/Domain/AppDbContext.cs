using matallurgical_plant.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matallurgical_plant.Domain
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Specification> Spetifications { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                NameProduct = "Металлический пластина 1x1m",
                Price = 50,
                Quantity = 120,
                Material = "Аллюминий"
            },
            new Product
            {
                Id = 2,
                NameProduct = "sdfsdfsdf",
                Price = 530,
                Quantity = 2120,
                Material = "Жевамб"
            });
        }
    }
}
