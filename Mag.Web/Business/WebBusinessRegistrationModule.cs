using Autofac;

namespace Mag.Web.Business
{
    public class WebBusinessRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserServiceFacade>()
                .As<IUserServiceFacade>()
                .SingleInstance();
        }
    }
}