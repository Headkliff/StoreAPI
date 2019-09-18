using Microsoft.EntityFrameworkCore;
using Store.Entity.Models;

namespace Store.Entity.Db
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

    }
}
