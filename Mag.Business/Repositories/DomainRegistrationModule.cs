using System.Configuration;

using Autofac;

using Mag.Business.Abstract;

namespace Mag.Business.Repositories
{
    public class DomainRegistrationModule : Module
    {
        private const string ConnectionStringParam = "connectionString";

        protected override void Load(ContainerBuilder builder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            builder.RegisterType<SalesRepository>()
                .As<ISalesRepository>()
                .WithParameter(ConnectionStringParam, connectionString)
                .SingleInstance();

            builder.RegisterType<SqlAgentRepository>()
                .As<IAgentsRepository>()
                .WithParameter(ConnectionStringParam, connectionString)
                .SingleInstance();
            builder.RegisterType<SqlInsuranceTypesRepository>()
                .As<IInsuranceTypesRepository>()
                .WithParameter(ConnectionStringParam, connectionString)
                .SingleInstance();
        }
    }
}