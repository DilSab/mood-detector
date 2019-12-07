using System.Web;
using System.Web.Optimization;

namespace MoodDetectorWebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Assets/css/lib/bootstrap.css",
                      "~/Assets/css/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Assets/js/lib/jquery.js"));
            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                "~/Assets/js/lib/popper.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Assets/js/lib/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/d3.v5.min").Include(
               "~/Assets/js/lib/d3.v5.min.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
