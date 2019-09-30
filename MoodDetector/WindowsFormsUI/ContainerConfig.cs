using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Model;
using Controller;

namespace WindowsFormsUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LoginProcessor>().As<ILoginProcessor>();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Model)))
                .Where(t => t.Namespace.Contains("Service"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Controller)))
                .Where(t => t.Namespace.Contains("Service"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
