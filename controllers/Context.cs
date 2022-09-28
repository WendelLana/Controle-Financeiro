using ControleFinanceiro.models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ControleFinanceiro.controllers
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Category> Outcome { get; set; }
        public DbSet<Category> Income { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(GetCategories());
            base.OnModelCreating(modelBuilder);
        }

        private static Category[] GetCategories()
        {
            return new Category[]
            {
            new Category
            {
                categoryId = Guid.NewGuid(),
                name = "Contas de Água",
                color = "blue",
                icon = "src/water.jpg"
                
            },
            new Category
            {
                categoryId = Guid.NewGuid(),
                name = "Fatura do cartão",
                color = "gray",
                icon = "src/card.jpg"
            }
            };
        }
    }
}
