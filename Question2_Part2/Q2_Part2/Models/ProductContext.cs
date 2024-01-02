using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Q2_Part2.Models
{
    public partial class ProductContext : DbContext
    {
        public ProductContext()
        {
        }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProductInfo> ProductInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-CK15LFF\\SQLEXPRESS;database=Product;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductInfo>(entity =>
            {
                entity.ToTable("Product_Info");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
