using Moq;
using ShopHub.SecondaryPorts.ProductCategory;
using ShopHub.SecondaryPorts.ProductCategory.Models;

namespace ShopHub.UnitTests.ProductCategory.Mocks
{
    public class CategoryRepositoryMock
    {
        static List<Category> categories = TestData.Constants.Categories;

        public static ICategoryRepository MakeMock()
        {
            var repository = new Mock<ICategoryRepository>();

            repository
                .Setup(repo => repo.Create(It.IsAny<Category>()))
                .Returns<Category>(category => Create(category));

            repository
                .Setup(repo => repo.Get(It.IsAny<string>()))
                .Returns<string>(categoryId => Get(categoryId));

            repository
                .Setup(repo => repo.Delete(It.IsAny<string>()))
                .Returns<string>(categoryId => Delete(categoryId));

            repository
                .Setup(repo => repo.Update(It.IsAny<Category>()))
                .Returns<Category>(category => Update(category));

            repository
                .Setup(repo => repo.GetAll())
                .Returns(GetAll());

            return repository.Object;
        }

        private static async Task<string> Create(Category category)
        {
            category.Id = Guid.NewGuid();
            categories.Add(category);
            return await Task.FromResult(category.Id.ToString());
        }
        private static async Task<Category?> Get(string id)
        {
            return await Task.FromResult(categories.Find(category => category.Id.ToString() == id));
        }

        private static async Task<string?> Delete(string id)
        {
            var foundCategory = categories.Find(category => category.Id.ToString() == id);

            if (foundCategory != null)
            {
                categories.Remove(foundCategory);

                return await Task.FromResult(id);
            }

            return null;
        }

        private static async Task<string?> Update(Category category)
        {
            var foundIndex = categories.FindIndex(x => x.Id == category.Id);

            if (foundIndex != -1)
            {
                categories[foundIndex] = category;

                return await Task.FromResult(category.Id.ToString());
            }

            return null;
        }

        private static async Task<IEnumerable<Category>> GetAll()
        {
            return await Task.FromResult(categories);
        }

    }
}
