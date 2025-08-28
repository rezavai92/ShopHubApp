
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

        public async Task<string> Delete(string id)
        {
            return await _categoryProvider.Delete(id);
        }

        public async Task<CategoryDto> Get(string categoryId)
        {
            return await _categoryProvider.Get(categoryId); 
        }

        public async Task<CategoriesDto> GetAll()
        {
            return await _categoryProvider.GetAll();
        }

        public async Task<string> Update(UpdateCategoryDto updateCategoryDto)
        {
            return await _categoryProvider.Update(updateCategoryDto);
        }
    }
}
