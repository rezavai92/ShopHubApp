using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ShopHub.SecondaryAdapters.ProductCategory;
using ShopHub.SecondaryPorts.DbContexts;
using ShopHub.SecondaryPorts.ProductCategory;

namespace ShopHub.SecondaryAdapters
{
    public class AutofacRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
         
            builder.RegisterType<CategoryRepository>()
           .As<ICategoryRepository>()
           .InstancePerLifetimeScope();
        }
    }
}
