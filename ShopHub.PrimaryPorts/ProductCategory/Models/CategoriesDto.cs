using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopHub.PrimaryPorts.ProductCategory.Models
{
    public class CategoriesDto
    {
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
