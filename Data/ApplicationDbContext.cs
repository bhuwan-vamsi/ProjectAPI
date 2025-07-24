using APIPractice.Models.Domain;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

namespace APIPractice.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<TaskHistory> TasksHistory { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fruits & Vegetables" },
                new Category { Id = 2, Name = "Eggs, Meat & Fish" },
                new Category { Id = 3, Name = "Snacks & Branded Foods" },
                new Category { Id = 4, Name = "Baby Care" },
                new Category { Id = 5, Name = "Bakery, Cakes & Diary" },
                new Category { Id = 6, Name = "Beverages" }
                );
        }
    }     
}
