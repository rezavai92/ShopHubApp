using ShopHub.PrimaryPorts.ProductCategory.Models;

namespace ShopHub.PrimaryPorts.ProductCategory
{
    public interface ICategoryAdapter
    {
        Task<string> Create(CreateCategoryDto createCategoryDto);
    }
}
