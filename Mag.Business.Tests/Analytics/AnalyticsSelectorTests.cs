using System;
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
        public void IfNoRecordShowOnlyTotalAndNoException_Test()
        {
            var salesRepository = SetupSalesRepositoryReadSales();
            var selector = new AnalyticsSelector(salesRepository);
            var results = selector.CalculateReport(FilterFactory.AllTime).ToArray();

            Assert.AreEqual(1, results.Count());
            Assert.AreEqual(0, results[0].TotalSum);
        }

        [Test]
        public void SalesWithSameInsuranceAreGrouped_Test()
        {
            var repo = SetupSalesRepositoryReadSales(new[]
            {
                SaleFactory.NewSale.Insurance(InsuranceFactory.A).PaidSum(100).ContractsNumber(1),
                SaleFactory.NewSale.Insurance(InsuranceFactory.B).PaidSum(400).ContractsNumber(1),
                SaleFactory.NewSale.Insurance(InsuranceFactory.A).PaidSum(200).ContractsNumber(1)
            });

            var results = new AnalyticsSelector(repo).CalculateReport(FilterFactory.AllTime).ToArray();

            Assert.AreEqual(3, results.Count());
            Assert.AreEqual("A", results[0].CategoryName);
            Assert.AreEqual("B", results[1].CategoryName);
            Assert.AreEqual(300, results[0].TotalSum);
            Assert.AreEqual(400, results[1].TotalSum);
            Assert.AreEqual(2, results[0].TotalContractsNumber);
            Assert.AreEqual(1, results[1].TotalContractsNumber);
        }

        [Test]
        public void SelectOnlySalesWithin2ndQuarterAndCheckOrder_Test()
        {
            var repo = SetupSalesRepositoryReadSales(new[]
            {
                SaleFactory.NewSale.PaidSum(1).CreateDate(DateHelper.YearEnd),
                SaleFactory.NewSale.PaidSum(2).CreateDate(DateHelper.YearBegin),

                // boundary conditions!
                SaleFactory.NewSale.PaidSum(300).CreateDate(new DateTime(DateHelper.CurrentYear, 4, 1)), 
                
                // boundary conditions: end date is included
                SaleFactory.NewSale.PaidSum(50).CreateDate(new DateTime(DateHelper.CurrentYear, 7, 1)),
                
                // boundary conditions, last day of quarter month is included!
                SaleFactory.NewSale.PaidSum(100).CreateDate(new DateTime(DateHelper.CurrentYear, 6, 30)),
                
                // something in between
                SaleFactory.NewSale.PaidSum(500).CreateDate(new DateTime(DateHelper.CurrentYear, 5, 5))
            });

            var results = new AnalyticsSelector(repo).CalculateReport(FilterFactory.Quart2).ToArray();
            Assert.AreEqual(5, results.Count());
            Assert.AreEqual(300, results[0].TotalSum); // april
            Assert.AreEqual(500, results[1].TotalSum); // may
            Assert.AreEqual(100, results[2].TotalSum); // july
            Assert.AreEqual(50, results[3].TotalSum); // july
        }

        [Test]
        public void SumOnlySalesWithin2ndQuarter_Test()
        {
            var repo = SetupSalesRepositoryReadSales(new[]
            {
                SaleFactory.NewSale.Insurance(InsuranceFactory.A).PaidSum(1).CreateDate(DateHelper.YearEnd),
                SaleFactory.NewSale.Insurance(InsuranceFactory.A).PaidSum(2).CreateDate(DateHelper.YearBegin),

                // included!
                SaleFactory.NewSale.Insurance(InsuranceFactory.A).PaidSum(300).CreateDate(new DateTime(DateHelper.CurrentYear, 4, 1)), 
                
                // included (the last date)
                SaleFactory.NewSale.Insurance(InsuranceFactory.A).PaidSum(50).CreateDate(new DateTime(DateHelper.CurrentYear, 7, 1)),
                
                // last day of quarter month is included!
                SaleFactory.NewSale.Insurance(InsuranceFactory.A).PaidSum(100).CreateDate(new DateTime(DateHelper.CurrentYear, 6, 30)),
                
                // included something in between
                SaleFactory.NewSale.Insurance(InsuranceFactory.A).PaidSum(500).CreateDate(new DateTime(DateHelper.CurrentYear, 5, 5)),
            });

            var results = new AnalyticsSelector(repo).CalculateReport(FilterFactory.Quart2).ToArray();
            Assert.AreEqual(2, results.Count());

            // 300 + 500 + 100 + 50 = 950
            Assert.AreEqual(950, results[0].TotalSum);
        }

        [Test]
        public void TotalIsSumEvenIfInsuranceTypesDiffer_Test()
        {
            var repo = SetupSalesRepositoryReadSales(new[]
            {
                SaleFactory.NewSale.PaidSum(100).Insurance(InsuranceFactory.A),
                SaleFactory.NewSale.PaidSum(200).Insurance(InsuranceFactory.B)
            });
            var results = new AnalyticsSelector(repo).CalculateReport(FilterFactory.AllTime).ToArray();
            Assert.AreEqual(3, results.Length);
            Assert.AreEqual(300, results.Last().TotalSum);
        }
    }
}
