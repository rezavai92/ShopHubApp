using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopHub.PrimaryPorts.ProductCategory.Models;
using ShopHub.SecondaryPorts.ProductCategory.Models;

namespace ShopHub.BusinessLogic.ProductCategory.Converter
{
    internal static class CategoryDtoConverter
    {
        public static CategoryDto Convert(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id.ToString(),
                Name = category.Name,
            };
        }
    }
}
