
using ShopHub.PrimaryPorts.ProductCategory;
using ShopHub.PrimaryPorts.ProductCategory.Models;

namespace ShopHub.PrimaryAdapters.ProductCategory
{
    public class CategoryAdapter : ICategoryAdapter
    {
        private readonly ICategoryProvider _categoryProvider;

        public CategoryAdapter(ICategoryProvider categoryProvider)
        {
            _categoryProvider = categoryProvider;
        }

        public async Task<string> Create(CreateCategoryDto createCategoryDto)
        {
            return await _categoryProvider.Create(createCategoryDto);
        }
    }
}
