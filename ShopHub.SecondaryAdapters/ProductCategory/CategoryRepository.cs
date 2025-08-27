
using ShopHub.SecondaryPorts.DbContexts;
using ShopHub.SecondaryPorts.ProductCategory;
using ShopHub.SecondaryPorts.ProductCategory.Models;

namespace ShopHub.SecondaryAdapters.ProductCategory
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlApplicationDbContext _dbContext;
        public CategoryRepository(SqlApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Create(Category category)
        {
            await _dbContext.AddAsync<Category>(category);
            await _dbContext.SaveChangesAsync();

            return category.Id.ToString();
        }
    }
}
