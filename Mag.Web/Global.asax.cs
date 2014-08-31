using System;
using System.Web;
using System.Web.Optimization;

using Mag.Web.App_Start;
using Mag.Web.AutofacSupport;

namespace Mag.Web
{
    public class Global : HttpApplication
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();

            log.Debug("Application started");

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