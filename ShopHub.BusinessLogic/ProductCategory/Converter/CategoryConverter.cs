using ShopHub.PrimaryPorts.ProductCategory.Models;
using ShopHub.SecondaryPorts.ProductCategory.Models;

namespace ShopHub.BusinessLogic.ProductCategory.Converter
{
    internal static class CategoryConverter
    {
        public static Category Convert(CreateCategoryDto categoryDto)
        {
            return new Category 
            { 
                Name = categoryDto.Name, 
                Description = categoryDto.Description
            };
        }
    }
}
