
using Microsoft.EntityFrameworkCore;
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

        public async Task Delete(string categoryId)
        {
            var deletableCategory = await _dbContext.Categories.SingleOrDefaultAsync(item => item.Id.ToString() == categoryId);

            if(deletableCategory != null)
            {
                _dbContext.Categories.Remove(deletableCategory);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Category> Get(string categoryId)
        {
            return await _dbContext.Categories.FindAsync(new Guid(categoryId));
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext.Categories.ToListAsync();    
        }

        public async Task Update(Category category)
        {
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
