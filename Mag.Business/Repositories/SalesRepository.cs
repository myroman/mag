using System;
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
                var sale = Read(entity.id);
                sales.Add(sale);
            }

            return sales;
        }

        public Sale Read(int id)
        {
            var entity = DataContext.tbSales.SingleOrDefault(x => x.id == id);
            if (entity == null)
            {
                return null;
            }

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
            return sale;
        }

        public Sale Add(Sale sale)
        {
            var item = sale.ToItem();
            DataContext.tbSales.InsertOnSubmit(item);
            DataContext.SubmitChanges();

            sale.Id = item.id;
            return sale;
        }

        public void Remove(IEnumerable<int> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException("ids");
            }
            if (!ids.Any())
            {
                return;
            }
            foreach (var saleId in ids)
            {
                var item = DataContext.tbSales.SingleOrDefault(x => x.id == saleId);
                if (item == null)
                {
                    throw new DomainException(string.Format("Sale с id={0} не найден и не может быть удален.", saleId));
                }
                DataContext.tbSales.DeleteOnSubmit(item);
            }

            DataContext.SubmitChanges();
        }
    }
}