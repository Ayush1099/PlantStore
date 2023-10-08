using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PlantNursery.Models
{
    public partial class PlantNurseryDBContext : DbContext
    {
        public PlantNurseryDBContext()
        {
        }

        public PlantNurseryDBContext(DbContextOptions<PlantNurseryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Plants> Plants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB;Initial Catalog=PlantNurseryDB;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plants>(entity =>
            {
                entity.HasIndex(e => e.PlantName, "uq_ProductName")
                    .IsUnique();

                entity.Property(e => e.PlantId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PlantName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("numeric(8, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
