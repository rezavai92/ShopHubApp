using Microsoft.EntityFrameworkCore;
using ShopHub.SecondaryPorts.ProductCategory.Models;

namespace ShopHub.SecondaryPorts.DbContexts
{
    public class SqlApplicationDbContext : DbContext
    {
        public SqlApplicationDbContext(DbContextOptions<SqlApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
