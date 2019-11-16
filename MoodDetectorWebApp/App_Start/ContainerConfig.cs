using Autofac;
using ControllerProject;
using Model;
using System.Reflection;
using System.Linq;
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
            builder.RegisterType<MoodDetectorDBEntities>().As<MoodDetectorDBEntities>().SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Model)))
                .Where(t => t.Namespace.Contains("Service"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name)).InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(ControllerProject)))
                .Where(t => t.Namespace.Contains("Service"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name)).InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
