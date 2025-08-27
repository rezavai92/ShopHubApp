using Autofac;
using ShopHub.PrimaryAdapters.ProductCategory;
using ShopHub.PrimaryPorts.ProductCategory;

namespace ShopHub.PrimaryAdapters
{
    public class AutofacRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryAdapter>()
           .As<ICategoryAdapter>()
           .InstancePerLifetimeScope();
        }
    }

}
