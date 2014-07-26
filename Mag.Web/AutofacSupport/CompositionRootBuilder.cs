using Autofac;

using Mag.Business.Repositories;

namespace Mag.Web.AutofacSupport
{
    public class CompositionRootBuilder
    {
        public static IContainer Build()
        {
            // TODO: setup linq2sql connection issues.
            var builder = new ContainerBuilder();

            builder.RegisterModule<DomainRegistrationModule>();

            return builder.Build();
        }
    }
}