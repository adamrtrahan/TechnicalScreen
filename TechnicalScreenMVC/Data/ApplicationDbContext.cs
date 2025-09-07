using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TechnicalScreenMVC.Models;

namespace TechnicalScreenMVC.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PurchaseDetailViewModel> PurchaseDetailViewModels { get; set; }
    public virtual DbSet<PurchaseDetailUpdateModel> PurchaseDetailUpdateModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TechnicalScreen;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PurchaseDetailViewModel>(entity => { });

        modelBuilder.Entity<PurchaseDetailUpdateModel>(entity =>
        {
            entity
                .ToTable("PurchaseDetailItem")
                .HasKey(e => e.PurchaseDetailItemAutoId);

            entity.Property(e => e.ItemDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ItemName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedByUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e.PurchaseDetailItemAutoId).ValueGeneratedOnAdd();
            entity.Property(e => e.PurchaseOrderNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
