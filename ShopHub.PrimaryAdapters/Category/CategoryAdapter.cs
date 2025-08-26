using ShopHub.PrimaryPorts.Category;
using ShopHub.PrimaryPorts.Category.Models;

namespace ShopHub.PrimaryAdapters.Category
{
    public class CategoryAdapter : ICategoryAdapter
    {
        private ICategoryProvider _categoryProvider;

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
