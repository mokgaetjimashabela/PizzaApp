using PizzaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Identity.Client;

namespace PizzaApp.Data
{
    public class PizzaDbContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Margherita", Description = "Classic cheese & tomato", Price = 8.99m },
                new Pizza { Id = 2, Name = "Pepperoni", Description = "Loaded with pepperoni slices", Price = 10.99m,  },
                new Pizza { Id = 3, Name = "BBQ Chicken", Description = "BBQ sauce with grilled chicken", Price = 12.99m }
            );

            
        }
    }
}
