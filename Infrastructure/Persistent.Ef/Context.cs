using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistent.Ef
{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
