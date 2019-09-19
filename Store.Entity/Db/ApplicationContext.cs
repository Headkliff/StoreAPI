using System;
using Microsoft.EntityFrameworkCore;
using Store.Entity.Models;

namespace Store.Entity.Db
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User( 1L,"Standard 1",  "123456789", "test",  "test","User")
            );
        }
    }
}
