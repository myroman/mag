using System.Collections.Generic;
using System.Linq;

using Mag.Business.Abstract;
using Mag.Business.Domain;
using Mag.Business.Services;

using Moq;

using NUnit.Framework;

namespace Mag.Business.Tests.Analytics
{
    [TestFixture]
    [Category("AnalyticsSelector")]
    public class AnalyticsSelectorTests
    {
        private ISalesRepository SetupSalesRepositoryReadSales(IEnumerable<Sale> whatToReturn = null)
        {
            var salesRepMock = new Mock<ISalesRepository>();
            salesRepMock.Setup(x => x.ReadSales()).Returns(whatToReturn ?? new Sale[0]);

            return salesRepMock.Object;
        }

        [Test]
        public void SelectZeroRecords_NoException_Test()
        {
            var salesRepository = SetupSalesRepositoryReadSales();
            var selector = new AnalyticsSelector(salesRepository);
            var results = selector.CalculateReport(FilterFactory.AllTime);

            Assert.AreEqual(0, results.Count());
        }

        [Test]
        public void SalesWithSameInsuranceAreGrouped_Test()
        {
            var repo = SetupSalesRepositoryReadSales(new[]
            {
                new Sale
                {
                    Insurance = InsuranceTypeFactory.A,
                    PaidSum = 100,
                    ContractsNumber = 1
                }, 
                new Sale
                {
                    Insurance = InsuranceTypeFactory.B,
                    PaidSum = 400,
                    ContractsNumber = 1
                },
                new Sale
                {
                    Insurance = InsuranceTypeFactory.A,
                    PaidSum = 200,
                    ContractsNumber = 1
                }
            });

            var results = new AnalyticsSelector(repo).CalculateReport(FilterFactory.AllTime).ToArray();

            Assert.AreEqual(2, results.Count());
            Assert.AreEqual("A", results[0].InsuranceType);
            Assert.AreEqual("B", results[1].InsuranceType);
            Assert.AreEqual(300, results[0].TotalSum);
            Assert.AreEqual(400, results[1].TotalSum);
            Assert.AreEqual(2, results[0].TotalContractsNumber);
            Assert.AreEqual(1, results[1].TotalContractsNumber);
        }
    }
}
