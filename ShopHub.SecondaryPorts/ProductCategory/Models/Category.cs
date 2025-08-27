using ShopHub.Shared.Common.Models;

namespace ShopHub.SecondaryPorts.ProductCategory.Models
{
    public class Category : EntityBase
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
