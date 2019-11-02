using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Model;
using ControllerProject;

namespace WindowsFormsUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LoginProcessor>().As<ILoginProcessor>();
            builder.RegisterType<MoodDetectorDBEntities>().As<MoodDetectorDBEntities>();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Model)))
                .Where(t => t.Namespace.Contains("Service"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(ControllerProject)))
                .Where(t => t.Namespace.Contains("Service"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
