using ShopHub.PrimaryPorts.ProductCategory.Models;

namespace ShopHub.PrimaryPorts.ProductCategory
{
    public interface ICategoryProvider
    {
        Task<string> Create(CreateCategoryDto createCategoryDto);
        Task<CategoryDto> Get(string categoryId);
        Task<CategoriesDto> GetAll();
        Task<string> Update(UpdateCategoryDto updateCategoryDto);
        Task<string> Delete(string categoryId);
    }
}
