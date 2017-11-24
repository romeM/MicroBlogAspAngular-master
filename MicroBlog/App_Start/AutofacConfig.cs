using Autofac;
using Autofac.Integration.WebApi;
using MicroBlog.Data;
using System.Reflection;
using System.Web.Http;

namespace MicroBlog
{
    public static class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // Dependendy Injection of the MicroblogContext
            builder.RegisterType<MicroBlogContext>().As<MicroBlogContext>().InstancePerLifetimeScope();

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}