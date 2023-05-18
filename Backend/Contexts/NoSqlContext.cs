﻿using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Contexts
{
    public class NoSqlContext : DbContext
    {
        public NoSqlContext(DbContextOptions<NoSqlContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> ProductsCatalog { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PromoCodeEntity> PromoCodes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .ToContainer("productCatalog")
                .HasPartitionKey(x => x.Id);

            modelBuilder.Entity<OrderEntity>()
                .ToContainer("orders")
                .HasPartitionKey(x => x.Id);
        }
    }
}
