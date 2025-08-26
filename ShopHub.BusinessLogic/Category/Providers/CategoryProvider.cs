using ShopHub.PrimaryPorts.Category;
using ShopHub.PrimaryPorts.Category.Models;
using ICategoryAdapter = ShopHub.SecondaryPorts.Category.ICategoryAdapter;

namespace ShopHub.BusinessLogic.Category.Providers
{
    public class CategoryProvider : ICategoryProvider
    {
        private ICategoryAdapter _categoryAdapter;

        public CategoryProvider(ICategoryAdapter categoryAdapter)
        {
            _categoryAdapter = categoryAdapter;
        }

        public async Task<string> Create(CreateCategoryDto createCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
