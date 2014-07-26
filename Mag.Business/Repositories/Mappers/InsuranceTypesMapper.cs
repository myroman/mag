using Mag.Business.Domain;

namespace Mag.Business.Repositories.Mappers
{
    public static class InsuranceTypesMapper
    {
        public static InsuranceType ToDomain(this tbInsuranceType from)
        {
            return new InsuranceType
                {
                    Id = from.id,
                    Name = from.name
                };
        }
    }
}