using ShopHub.SecondaryPorts.ProductCategory.Models;

namespace ShopHub.UnitTests.ProductCategory.TestData
{
    public static class Constants
    {
        public static List<Category> Categories = new List<Category>
        {
            new Category
            {
                Id = Guid.NewGuid(),
                IsDeleted = false,
                Name = "Category 1",
                CreatedAt = DateTime.Now,
                Description = "Description",
                UpdatedAt = DateTime.Now,
            },
            new Category
            {
                Id = Guid.NewGuid(),
                IsDeleted = false,
                Name = "Category 2",
                CreatedAt = DateTime.Now,
                Description = "Description",
                UpdatedAt = DateTime.Now,
            },
            new Category
            {
                Id = Guid.NewGuid(),
                IsDeleted = false,
                Name = "Category 3",
                CreatedAt = DateTime.Now,
                Description = "Description",
                UpdatedAt = DateTime.Now,
            }

        };
    }
}
