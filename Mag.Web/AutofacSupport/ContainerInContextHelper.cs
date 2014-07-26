using System.Web;

using Autofac;

namespace Mag.Web.AutofacSupport
{
    public static class ContainerInContextHelper
    {
        public static void SetCompositionRoot(this HttpContext context, IContainer value)
        {
            HttpContext.Current.Application["iocContainer"] = value;
        }

        public static IContainer GetContainer(this HttpContext context)
        {
            return (IContainer)HttpContext.Current.Application["iocContainer"];
        }
    }
}