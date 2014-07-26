using Autofac;

using Mag.Business.Repositories;
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

            return builder.Build();
        }
    }
}