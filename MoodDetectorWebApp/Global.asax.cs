using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web;
using System;
using System.Linq;
using Model;

namespace MoodDetectorWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ContainerConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);         
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {                                     
                        string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        string roles = string.Empty;

                        using (MoodDetectorDBEntities entities = new MoodDetectorDBEntities())
                        {
                            LoginInfo user = entities.LoginInfoes.SingleOrDefault(u => u.Username == username);

                            roles = user.User.AccessRights;
                        }
                  
                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                        new System.Security.Principal.GenericIdentity(username, "Forms"), roles.Split(';'));
                        
                    }
                    catch (Exception)
                    {
                       
                    }
                }
            }
        }

    }

}
