using System.Web;

using Autofac;

using Mag.Web.AutofacSupport;
using Mag.Web.Handlers.ApiControllers;

namespace Mag.Web.Handlers
{
    public class ApiHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var container = context.GetContainer();
            var entity = context.Request["entity"];
            IApiController controller;
            switch (entity)
            {
                case "sale":
                    controller = container.Resolve<SaleController>(new NamedParameter("context", context));
                    break;
                case "anlsMag":
                    controller = container.Resolve<AnalyticsController>(new NamedParameter("context", context));
                    break;
                default:
                    controller = null;
                    break;
            }
            if (controller != null)
            {
                controller.ProcessRequest();
                return;
            }

            context.Response.StatusCode = 404;
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}