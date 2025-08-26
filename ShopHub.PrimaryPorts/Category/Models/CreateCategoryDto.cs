using System.ComponentModel.DataAnnotations;

namespace ShopHub.PrimaryPorts.Category.Models
{
    public class CreateCategoryDto
    {
        [Required]
        public required string name { get; set; }

        public string? description { get; set; }
    }
}
