using System;
using System.Web;
using System.Web.Optimization;

using Mag.Web.App_Start;
using Mag.Web.AutofacSupport;

namespace Mag.Web
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Context.SetCompositionRoot(CompositionRootBuilder.Build());
        }

        private void Application_End(object sender, EventArgs e)
        {
        }

        private void Application_Error(object sender, EventArgs e)
        {
        }
    }
}