using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ShopHub.BusinessLogic.ProductCategory.Providers;
using ShopHub.PrimaryPorts.ProductCategory;
using ShopHub.SecondaryPorts.ProductCategory;

namespace ShopHub.BusinessLogic
{
    public class AutofacRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<CategoryProvider>()
       .As<ICategoryProvider>()
       .InstancePerLifetimeScope();

        }
    }
}
