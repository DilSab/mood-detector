using Autofac;
using ControllerProject;
using Model;
using System.Reflection;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

namespace MoodDetectorWebApp
{
    public class ContainerConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            builder.RegisterType<LoginProcessor>().As<ILoginProcessor>().InstancePerRequest();
            builder.RegisterType<MoodDetectorDBEntities>().As<MoodDetectorDBEntities>().InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Model)))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(ControllerProject)))
                .AsImplementedInterfaces();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
