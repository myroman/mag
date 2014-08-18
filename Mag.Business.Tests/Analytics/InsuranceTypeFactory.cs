using Mag.Business.Domain;

namespace Mag.Business.Tests.Analytics
{
    public static class InsuranceTypeFactory
    {
        public static InsuranceType A
        {
            get
            {
                return new InsuranceType
                {
                    Id = 1,
                    Name = "A"
                };
            }
        }

        public static InsuranceType B
        {
            get
            {
                return new InsuranceType
                {
                    Id = 2,
                    Name = "B"
                };
            }
        }
    }
}