using System;
using System.Windows.Forms;
using Autofac;
using Controller;
using Controller.Service;

namespace WindowsFormsUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var loginProcessor = scope.Resolve<ILoginProcessor>();
                var userService = scope.Resolve<IUserService>();
                var moodService = scope.Resolve<IMoodService>();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginForm(loginProcessor, userService, moodService));
            }
        }
    }
}
