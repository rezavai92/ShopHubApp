using ShopHub.Shared.Common.Models;

namespace ShopHub.SecondaryAdapters.Category.Models
{
    public class Category : EntityBase
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
