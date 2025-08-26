using Autofac;
using ShopHub.PrimaryAdapters.Category;
using ShopHub.PrimaryPorts.Category;

namespace ShopHub.PrimaryAdapters
{
    public class AutofacRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new CategoryAdapter(c.Resolve<ICategoryProvider>()))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }

}
