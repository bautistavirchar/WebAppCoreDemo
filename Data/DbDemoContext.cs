using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppCoreDemo.Data
{
    public partial class DbDemoContext : DbContext
    {
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<OrderedItems> OrderedItems { get; set; }
        public virtual DbSet<OrderedStatus> OrderedStatus { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        public static string GetConnectionString{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<OrderedItems>(entity =>
            {
                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.OrderedItems)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.OrderedItems)
                    .HasForeignKey(d => d.Product)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.OrderedItems)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemStatus");
            });

            modelBuilder.Entity<OrderedStatus>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductStatus");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
