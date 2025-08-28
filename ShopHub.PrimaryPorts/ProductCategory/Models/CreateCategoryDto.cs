using System.ComponentModel.DataAnnotations;

namespace ShopHub.PrimaryPorts.ProductCategory.Models
{
    public class CreateCategoryDto
    {
        [Required]
        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}
