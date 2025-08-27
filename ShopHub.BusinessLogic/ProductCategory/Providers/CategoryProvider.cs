using ShopHub.BusinessLogic.ProductCategory.Converter;
using ShopHub.PrimaryPorts.ProductCategory;
using ShopHub.PrimaryPorts.ProductCategory.Models;
using ICategoryRepository = ShopHub.SecondaryPorts.ProductCategory.ICategoryRepository;

namespace ShopHub.BusinessLogic.ProductCategory.Providers
{
    public class CategoryProvider : ICategoryProvider
    {
        private ICategoryRepository _categoryAdapter;

        public CategoryProvider(ICategoryRepository categoryAdapter)
        {
            _categoryAdapter = categoryAdapter;
        }

        public async Task<string> Create(CreateCategoryDto createCategoryDto)
        {

            var category = CategoryConverter.Convert(createCategoryDto);

            return await _categoryAdapter.Create(category);
        }
    }
}
