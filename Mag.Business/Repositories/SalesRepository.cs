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
            try
            {
                Log.Info("Getting sales...");

                var sales = new List<Sale>();
                foreach (var entity in DataContext.tbSales)
                {
                    var sale = Read(entity.id);
                    sales.Add(sale);
                }
                Log.Info("OK");
                return sales;
            }
            catch (Exception exc)
            {
                Log.Error("Getting sales failed", exc);
                throw;
            }
        }

        public Sale Read(int id)
        {
            Log.InfoFormat("Reading sale id={0}", id);
            var entity = DataContext.tbSales.SingleOrDefault(x => x.id == id);
            if (entity == null)
            {
                Log.WarnFormat("No sale with id={0}", id);
                return null;
            }

            var sale = entity.ToDomain();
            sale.Agent = agentsRepository.Read(entity.agentId);
            if (sale.Agent == null)
            {
                Log.ErrorFormat("No agent with id={0}", entity.agentId);
                throw new DomainException("Agent is not set");
            }
            sale.Insurance = insuranceTypesRepository.Read(entity.insuranceTypeId);
            if (sale.Insurance == null)
            {
                Log.ErrorFormat("No insurance with id={0}", entity.insuranceTypeId);
                throw new DomainException("Insurance is not set");
            }
            return sale;
        }

        public Sale Add(Sale sale)
        {
            var item = sale.ToItem();
            try
            {
                Log.InfoFormat("Adding sale {0}", sale);
                DataContext.tbSales.InsertOnSubmit(item);
                DataContext.SubmitChanges();
            }
            catch (Exception exc)
            {
                Log.Error(string.Format("Can't add sale {0}", sale), exc);
                throw;
            }

            sale.Id = item.id;
            return sale;
        }

        public void Remove(IEnumerable<int> ids)
        {
            var strIds = string.Join(",", ids.Select(x => x.ToString()));
            Log.WarnFormat("Gonna delete sales with ids {0}", strIds);
            if (ids == null)
            {
                Log.WarnFormat("No ids supplied");
                throw new ArgumentNullException("ids");
            }
            if (!ids.Any())
            {
                Log.WarnFormat("No ids supplied");
                return;
            }
            foreach (var saleId in ids)
            {
                try
                {
                    var item = DataContext.tbSales.SingleOrDefault(x => x.id == saleId);
                    if (item == null)
                    {
                        var msg = string.Format("Sale с id={0} не найден и не может быть удален.", saleId);
                        Log.Warn(msg);
                        throw new DomainException(msg);
                    }
                    DataContext.tbSales.DeleteOnSubmit(item);
                }
                catch (Exception exc)
                {
                    Log.Error("Error during deleting sales", exc);
                    throw;
                }
            }

            DataContext.SubmitChanges();
            Log.InfoFormat("Sales with ids {0} have been removed", strIds);
        }
    }
}