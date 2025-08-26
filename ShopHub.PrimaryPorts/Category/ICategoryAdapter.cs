using ShopHub.PrimaryPorts.Category.Models;

namespace ShopHub.PrimaryPorts.Category
{
    public interface ICategoryAdapter
    {
        Task<string> Create(CreateCategoryDto createCategoryDto);
    }
}
