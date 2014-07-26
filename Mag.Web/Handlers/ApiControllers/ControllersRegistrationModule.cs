using Autofac;

namespace Mag.Web.Handlers.ApiControllers
{
    public class ControllersRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SaleController>()
                .As<IApiController>();
        }
    }
}