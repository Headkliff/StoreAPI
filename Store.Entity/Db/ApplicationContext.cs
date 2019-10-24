﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Entity.Models;

namespace Store.Entity.Db
{
    public sealed class ApplicationContext :DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> Types { get; set; }
        public DbSet<ItemCategory> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Nickname)
                .IsUnique();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is EntityBase baseEntry)
                {
                    var dateTime = DateTime.UtcNow;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            baseEntry.CreateDateTime = dateTime;
                            entry.CurrentValues["IsDeleted"] = false;
                            break;
                        case EntityState.Modified:
                            baseEntry.UpdateDateTime = dateTime;
                            break;
                    }
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
