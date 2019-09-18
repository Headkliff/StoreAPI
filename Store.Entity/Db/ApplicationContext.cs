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
                new User
                {
                    Nickname = "Standard 1", Password = "111", CreateDateTime = DateTime.Now, FirstName = "test",
                    Id= 1L, SecondName = "test1", UpdateDateTime = null, Role = "User"
                }
            );
        }
    }
}
