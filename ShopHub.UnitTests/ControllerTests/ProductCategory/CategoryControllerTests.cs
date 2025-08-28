using Autofac;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ClientProtocol;
using Moq;
using Shophub.Server.Controllers.ProductCategory;
using ShopHub.PrimaryAdapters.ProductCategory;
using ShopHub.PrimaryPorts.ProductCategory.Models;
using ShopHub.SecondaryPorts.ProductCategory;
using ShopHub.UnitTests.ControllerTests.ProductCategory.Mocks;

namespace ShopHub.UnitTests.ControllerTests.ProductCategory
{
    public class CategoryControllerTests
    {
        private static readonly IContainer container;
        static CategoryControllerTests()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CategoryController>(); 

            builder.RegisterAssemblyModules(typeof(ShopHub.PrimaryAdapters.AutofacRegistrationModule).Assembly);    
            builder.RegisterAssemblyModules(typeof(ShopHub.BusinessLogic.AutofacRegistrationModule).Assembly);

            builder.Register(c => CategoryRepositoryMock.MakeMock()).As<ICategoryRepository>().InstancePerLifetimeScope();

            container = builder.Build();
        }

        [Fact]
        public async Task CreateCategory_Category_ReturnsCreatedCategoryId()
        {
            var controller = container.Resolve<CategoryController>();
            var categoryDto = new CreateCategoryDto
            {
                Name = "Test Category",
                Description = "This is a test category"
            };  
            var newId = await controller.CreateCategory(categoryDto);

            newId.Should().NotBeNull();
        }
    }
}
