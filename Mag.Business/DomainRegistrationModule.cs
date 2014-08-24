using Autofac;

using Mag.Business.Abstract;

namespace Mag.Business
{
    public class DomainRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SettingsReader>()
                .As<IAccountSettings>()
                .SingleInstance();
        }
    }
}