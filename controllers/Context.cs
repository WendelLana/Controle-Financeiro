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
        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<Income> Incomes { get; set; }
    }
}
