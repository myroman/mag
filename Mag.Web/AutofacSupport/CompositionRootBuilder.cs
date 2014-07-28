using Autofac;

using Mag.Business.Repositories;
using Mag.Business.Services;
using Mag.Web.Business;
using Mag.Web.Handlers.ApiControllers;

namespace Mag.Web.AutofacSupport
{
    public class CompositionRootBuilder
    {
        public static IContainer Build()
        {
            // TODO: setup linq2sql connection issues.
            var builder = new ContainerBuilder();

            builder.RegisterModule<DomainRegistrationModule>();
            builder.RegisterModule<ControllersRegistrationModule>();
            builder.RegisterModule<ServiceRegistrationModule>();
            builder.RegisterModule<WebBusinessRegistrationModule>();

            return builder.Build();
        }
    }
}