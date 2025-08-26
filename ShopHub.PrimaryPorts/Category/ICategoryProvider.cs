using ShopHub.PrimaryPorts.Category.Models;

namespace ShopHub.PrimaryPorts.Category
{
    public interface ICategoryProvider
    {
        Task<string> Create(CreateCategoryDto createCategoryDto);
    }
}
