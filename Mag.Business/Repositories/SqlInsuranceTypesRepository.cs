﻿using System.Collections.Generic;
using System.Linq;

using Mag.Business.Abstract;
using Mag.Business.Domain;
using Mag.Business.Repositories.Mappers;

namespace Mag.Business.Repositories
{
    public class SqlInsuranceTypesRepository : SqlRepositoryBase, IInsuranceTypesRepository
    {
        public SqlInsuranceTypesRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<InsuranceType> List()
        {
            var insuranceTypes = DataContext.tbInsuranceTypes.Select(x => x.ToDomain()).ToArray();
            return insuranceTypes.OrderBy(x => x.Id);
        }

        public InsuranceType Read(int id)
        {
            var rec = DataContext.tbInsuranceTypes.SingleOrDefault(x => x.id == id);
            if (rec == null)
            {
                return null;
            }
            return rec.ToDomain();
        }
    }
}