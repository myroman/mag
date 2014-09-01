using System;

using Mag.Business.Domain;

namespace Mag.Business.Tests.Analytics
{
    public static class InsuranceFactory
    {
        private static Random randomInt = new Random();

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

        public static InsuranceType C
        {
            get
            {
                return new InsuranceType
                {
                    Id = 3,
                    Name = "C"
                };
            }
        }

        // use this if you need to set insurance for a set of sales, so that they aren't grouped.
        public static InsuranceType Rand
        {
            get
            {
                return new InsuranceType
                {
                    Id = randomInt.Next(),
                    Name = randomInt.Next().ToString()
                };
            }
        }

    }
}