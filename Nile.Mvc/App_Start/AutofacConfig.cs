using Autofac;
using Autofac.Integration.Mvc;
using ClassProject2.Data;
using ClassProject2.Data.Infrastructure;
using ClassProject2.Data.Repositories;
using System.Data.Entity;
using System.Web.Mvc;

namespace Nile.Mvc
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // init container
            var builder = new ContainerBuilder();

            // registration container in current assembly
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // registration types
            builder.RegisterType<DataContext>().As<DbContext>().SingleInstance();
            builder.RegisterType<DbFactory>().As<IDbFactory>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterGeneric(typeof(EntityBaseRepository<>)).As(typeof(IEntityBaseRepository<>));

            var container = builder.Build();

            // set DI-container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}