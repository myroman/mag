﻿using System.Collections.Generic;
using System.Linq;

using Mag.Business.Abstract;
using Mag.Business.Domain;
using Mag.Business.Repositories.Mappers;

namespace Mag.Business.Repositories
{
    public class SalesProvider : SqlRepositoryBase, ISalesProvider
    {
        private readonly IAgentsRepository agentsRepository;

        private readonly IInsuranceTypesRepository insuranceTypesRepository;

        public SalesProvider(
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
                sale.Insurance = insuranceTypesRepository.Read(entity.insuranceTypeId);

                sales.Add(sale);
            }

            return sales;
        }
    }
}