using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Store.Entity.Models;

namespace Store.Entity.Extensions
{
    public static class ChangeTrackerExtension
    {
        public static void SetDate(this ChangeTracker tracker)
        {
            foreach (var entry in tracker.Entries())
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
        }
    }
}
