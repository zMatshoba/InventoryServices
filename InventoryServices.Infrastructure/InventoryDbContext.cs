using InventoryServices.Application.Dtos.ReportDto;
using InventoryServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryServices.Infrastructure;

public class InventoryDbContext(DbContextOptions<InventoryDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> Items => Set<OrderItem>();
    public DbSet<DailySalesSqlResult> DailySalesViews => Set<DailySalesSqlResult>();

    public DbSet<InventoryAdjustment> InventoryAdjustments => Set<InventoryAdjustment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(product => product.Id);

            entity.HasIndex(product => product.Sku)
                  .IsUnique();
        });


        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(order => order.Id);

            entity.HasIndex(order => order.ExternalOrderNumber)
                  .IsUnique();
        });


        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(item => item.Id);

        });


        modelBuilder.Entity<InventoryAdjustment>(entity =>
        {
            entity.HasKey(adjustment => adjustment.Id);

        });

        modelBuilder.Entity<DailySalesSqlResult>()
            .HasNoKey();
    }
}
