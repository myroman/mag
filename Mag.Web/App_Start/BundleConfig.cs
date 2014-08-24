using System.Web.Optimization;

namespace Mag.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js/all").Include(
                "~/scripts/jquery-2.1.1.js",
                "~/scripts/jquery-ui.js",
                "~/scripts/knockout-3.1.0.js",
                "~/scripts/bootstrap.js",
                "~/scripts/my/koExtensions.js",
                "~/scripts/my/sales.js",
                "~/scripts/my/analytics.js"
                ));
            bundles.Add(new Bundle("~/bundles/css/jquery-ui").Include(
                "~/content/jquery-ui/jquery-ui.css"
                ));
        }
    }
}