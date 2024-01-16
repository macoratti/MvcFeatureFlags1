using Microsoft.EntityFrameworkCore;
using MvcFeatureFlags.Models;

namespace MvcFeatureFlags.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Caderno",
                Description = "Caderno Espiral",
                Price = 12.00m,
                Discount = 5.0m,
                Image = "caderno1.jpg",
                Stock = 12.0d,
                IsActive = true,
            },
            new Product
            {
                Id = 2,
                Name = "Cartilha",
                Description = "Cartilha Caminho Suave",
                Price = 17.00m,
                Discount = 7.0m,
                Image = "cartilha1.jpg",
                Stock = 14.0d,
                IsActive = true,
            },
            new Product
            {
                Id = 3,
                Name = "Borracha",
                Description = "Borracha branca",
                Price = 4.55m,
                Discount = 1.0m,
                Image = "borracha1.jpg",
                Stock = 42.0d,
                IsActive = true,
            },
            new Product
            {
                Id = 4,
                Name = "Calculadora",
                Description = "Calculadora simples",
                Price = 15.59m,
                Discount = 9.10m,
                Image = "calculadora1.jpg",
                Stock = 33.0d,
                IsActive = true,
            },
            new Product
            {
                Id = 5,
                Name = "Estojo",
                Description = "Estojo de madeira",
                Price = 22.30m,
                Discount = 7.0m,
                Image = "estojo1.jpg",
                Stock = 20.0d,
                IsActive = true,
            }
        );
    }
}
