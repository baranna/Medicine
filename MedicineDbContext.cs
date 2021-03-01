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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable(nameof(Product));
        }
    }
}
