using Autofac;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ClientProtocol;
using Moq;
using Shophub.Server.Controllers.ProductCategory;
using ShopHub.PrimaryAdapters.ProductCategory;
using ShopHub.PrimaryPorts.ProductCategory.Models;
using ShopHub.SecondaryPorts.ProductCategory;
using ShopHub.UnitTests.ProductCategory.Mocks;

namespace ShopHub.UnitTests.ProductCategory
{
    public class CategoryControllerTests
    {
        private static readonly IContainer container;
        static CategoryControllerTests()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CategoryController>();

            builder.RegisterAssemblyModules(typeof(PrimaryAdapters.AutofacRegistrationModule).Assembly);
            builder.RegisterAssemblyModules(typeof(BusinessLogic.AutofacRegistrationModule).Assembly);

            builder.Register(c => CategoryRepositoryMock.MakeMock()).As<ICategoryRepository>().InstancePerLifetimeScope();

            container = builder.Build();
        }

        [Theory]
        [InlineData("Test Category 1", "Test Category Description 1")]
        [InlineData("Test Category 2", "Test Category Description 2")]
        public async Task CreateCategory_Category_ReturnsCreatedCategoryId(string name, string descrption)
        {
            var controller = container.Resolve<CategoryController>();
            var categoryDto = new CreateCategoryDto
            {
                Name = name,
                Description = descrption
            };
            var response = await controller.CreateCategory(categoryDto);

            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCategory_CategoryId_ReturnsFoundCategory()
        {
            var controller = container.Resolve<CategoryController>();
            var id = TestData.Constants.Categories[0].Id.ToString();
            var response = await controller.GetCategory(id);

            response.Value.Should().NotBeNull();
            response.Value.Should().BeOfType<CategoryDto>();
        }

        [Fact]
        public async Task DeleteCategory_CategoryId_ReturnsDeletedCategoryId()
        {
            var controller = container.Resolve<CategoryController>();
            var id = TestData.Constants.Categories[0].Id.ToString();    
            var response = await controller.DeleteCategory(id);

            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAllCategories_NoInput_ReturnsAllCategories()
        {
            var controller = container.Resolve<CategoryController>();
            var response = await controller.GetAllCategories();
            response.Value.Should().NotBeNull();
            response.Value.Categories.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task UpdateCategory_Category_ReturnsUpdatedCategoryId()
        {
            var controller = container.Resolve<CategoryController>();
            var existingCategory = TestData.Constants.Categories[0];
            var updateCategoryDto = new UpdateCategoryDto
            {
                Id = existingCategory.Id.ToString(),
                Name = "Updated Name",
                Description = "Updated Description"
            };
            var response = await controller.UpdateCategory(updateCategoryDto);
            response.Value.Should().NotBeNull();
            response.Value.Should().Be(existingCategory.Id.ToString());
        }
    }
}
