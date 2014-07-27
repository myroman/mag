using System.Collections.Generic;
using System.Linq;

using Mag.Business.Abstract;
using Mag.Business.Domain;
using Mag.Business.Repositories.Mappers;

namespace Mag.Business.Repositories
{
    public class SalesRepository : SqlRepositoryBase, ISalesRepository
    {
        private readonly IAgentsRepository agentsRepository;

        private readonly IInsuranceTypesRepository insuranceTypesRepository;

        public SalesRepository(
            string connectionString,
            IAgentsRepository agentsRepository,
            IInsuranceTypesRepository insuranceTypesRepository)
            : base(connectionString)
        {
            this.agentsRepository = agentsRepository;
            this.insuranceTypesRepository = insuranceTypesRepository;
        }

        public IEnumerable<Sale> ReadSales()
        {
            var sales = new List<Sale>();
            foreach (var entity in DataContext.tbSales)
            {
                var sale = entity.ToDomain();
                sale.Agent = agentsRepository.Read(entity.agentId);
                if (sale.Agent == null)
                {
                    throw new DomainException("Agent is not set");
                }
                sale.Insurance = insuranceTypesRepository.Read(entity.insuranceTypeId);
                if (sale.Insurance == null)
                {
                    throw new DomainException("Insurance is not set");
                }
                sales.Add(sale);
            }

            return sales;
        }

        public Sale Add(Sale sale)
        {
            var item = sale.ToItem();
            DataContext.tbSales.InsertOnSubmit(item);
            DataContext.SubmitChanges();

            sale.Id = item.id;
            return sale;
        }
    }
}