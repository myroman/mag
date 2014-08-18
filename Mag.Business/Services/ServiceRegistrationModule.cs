using Autofac;

using Mag.Business.Abstract;

namespace Mag.Business.Services
{
    public class ServiceRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>()
                .As<IUserService>()
                .SingleInstance();

            builder.RegisterType<SimpleAes>();

            builder.RegisterType<AnalyticsSelector>()
                .As<IAnalyticsSelector>()
                .SingleInstance();
        }
    }
}