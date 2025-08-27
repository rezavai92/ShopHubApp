using ShopHub.PrimaryPorts.ProductCategory.Models;

namespace ShopHub.PrimaryPorts.ProductCategory
{
    public interface ICategoryProvider
    {
        Task<string> Create(CreateCategoryDto createCategoryDto);
    }
}
