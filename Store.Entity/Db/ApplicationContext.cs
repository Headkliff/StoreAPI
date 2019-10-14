using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Entity.Models;

namespace Store.Entity.Db
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }

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
