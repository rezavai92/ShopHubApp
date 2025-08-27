using ShopHub.SecondaryPorts.ProductCategory.Models;

namespace ShopHub.SecondaryPorts.ProductCategory
{
    public interface ICategoryRepository
    {
        Task<string> Create( Category category);
    }
}
