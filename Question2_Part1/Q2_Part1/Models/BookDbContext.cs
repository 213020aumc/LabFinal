using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Q2_Part1.Models
{
    public partial class BookDbContext : DbContext
    {
        public BookDbContext()
        {
        }

        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> BookInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-CK15LFF\\SQLEXPRESS;database=Book;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__Book_Inf__3DE0C2078D7FE96E");

                entity.ToTable("Book_Info");

                entity.Property(e => e.BookId).ValueGeneratedNever();

                entity.Property(e => e.BookAuthor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.Property(e => e.PublicationYear)
                    .HasMaxLength(50)
                    .HasColumnName("Publication_Year");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
