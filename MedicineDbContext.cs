using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medicine.Entity;
using Microsoft.EntityFrameworkCore;

namespace Medicine
{
    public class MedicineDbContext : DbContext
    {
        public MedicineDbContext(DbContextOptions<MedicineDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ActiveIngredient> ActiveIngredients { get; set; }

        public DbSet<ProductActiveIngredient> ProductActiveIngredients { get; set; }

        public DbSet<SideEffect> SideEffects { get; set; }

        public DbSet<SideEffectFrequency> SideEffectFrequencies { get; set; }

        public DbSet<Disease> Diseases { get; set; }

        public DbSet<Symptom> Symptoms { get; set; }

        public DbSet<Syndrome> Syndromes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable(nameof(Product));
            modelBuilder.Entity<SideEffect>().ToTable(nameof(SideEffect));
            modelBuilder.Entity<SideEffectFrequency>().ToTable(nameof(SideEffectFrequency));
            modelBuilder.Entity<ActiveIngredient>().ToTable(nameof(ActiveIngredient));
            modelBuilder.Entity<ProductActiveIngredient>().ToTable(nameof(ProductActiveIngredient));
            modelBuilder.Entity<Disease>().ToTable(nameof(Disease));
            modelBuilder.Entity<Symptom>().ToTable(nameof(Symptom));
            modelBuilder.Entity<Syndrome>().ToTable(nameof(Syndrome));
            base.OnModelCreating(modelBuilder);
        }
    }
}
