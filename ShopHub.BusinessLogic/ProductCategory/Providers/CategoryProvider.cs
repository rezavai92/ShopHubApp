using ShopHub.BusinessLogic.ProductCategory.Converter;
using ShopHub.PrimaryPorts.ProductCategory;
using ShopHub.PrimaryPorts.ProductCategory.Models;
using ShopHub.SecondaryPorts.ProductCategory.Models;
using ICategoryRepository = ShopHub.SecondaryPorts.ProductCategory.ICategoryRepository;

namespace ShopHub.BusinessLogic.ProductCategory.Providers
{
    public class CategoryProvider : ICategoryProvider
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryProvider(ICategoryRepository categoryAdapter)
        {
            _categoryRepository = categoryAdapter;
        }

        public async Task<string> Create(CreateCategoryDto createCategoryDto)
        {
            var category = CategoryConverter.Convert(createCategoryDto);

            return await _categoryRepository.Create(category);
        }

        public async Task<string> Delete(string categoryId)
        {
            await _categoryRepository.Delete(categoryId);

            return categoryId;
        }

        public async Task<CategoryDto> Get(string categoryId)
        {
            var category = await _categoryRepository.Get(categoryId);

            if(category != null)
            {
                var categoryDto = CategoryDtoConverter.Convert(category);

                return categoryDto;
            }
            else
            {
                throw new InvalidOperationException($"Category with id {categoryId} not found");
            }
        }

        public async Task<CategoriesDto> GetAll()
        {
            var categories = await _categoryRepository.GetAll() ?? new List<Category>();

            return new CategoriesDto
            {
                Categories = categories.Select(c => CategoryDtoConverter.Convert(c))
            };
        }

        public async Task<string> Update(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _categoryRepository.Get(updateCategoryDto.Id);
            
            if(category == null)
            {
                throw new InvalidOperationException();
            }

            category.Name = updateCategoryDto.Name;
            category.Description = updateCategoryDto.Description;

            await _categoryRepository.Update(category);

            return category.Id.ToString();
        }
    }
}
