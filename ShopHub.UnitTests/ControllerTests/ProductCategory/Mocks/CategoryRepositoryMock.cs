using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ShopHub.PrimaryPorts.ProductCategory.Models;
using ShopHub.SecondaryPorts.ProductCategory;
using ShopHub.SecondaryPorts.ProductCategory.Models;

namespace ShopHub.UnitTests.ControllerTests.ProductCategory.Mocks
{
    public class CategoryRepositoryMock
    {
        static List<Category> categories = new List<Category>();

        public static ICategoryRepository MakeMock()
        {
            var repository = new Mock<ICategoryRepository>();

            repository.Setup(repo => repo.Create(It.IsAny<Category>())).Returns<Category>(category => Create(category));

            return repository.Object;
        }

        private static async Task<string> Create(Category category)
        {
            category.Id = Guid.NewGuid();
            categories.Add(category);

            return category.Id.ToString();
        }
    }
}
