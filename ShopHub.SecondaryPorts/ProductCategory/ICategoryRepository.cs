using ShopHub.SecondaryPorts.ProductCategory.Models;

namespace ShopHub.SecondaryPorts.ProductCategory
{
    public interface ICategoryRepository
    {
        Task<string> Create( Category category);
        Task<Category?> Get( string categoryId);
        Task<IEnumerable<Category>> GetAll();
        Task Update(Category category);
        Task Delete(string categoryId);
    }
}
