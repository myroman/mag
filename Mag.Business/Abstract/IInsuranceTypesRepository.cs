using System.Collections.Generic;

using Mag.Business.Domain;

namespace Mag.Business.Abstract
{
    public interface IInsuranceTypesRepository
    {
        IEnumerable<InsuranceType> List();

        InsuranceType Read(int id);
    }
}