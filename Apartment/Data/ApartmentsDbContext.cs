using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Apartment.Data.Models;

namespace Apartment.Data;

public partial class ApartmentsDbContext : DbContext
{
    public ApartmentsDbContext()
    {
    }

    public ApartmentsDbContext(DbContextOptions<ApartmentsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Models.Apartment> Apartments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Apartment>(entity =>
        {
            entity.ToTable("Apartment");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.OwnerName)
                .IsRequired()
                .HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
