using PaySpace.TaxCalculator.Application.TaxCalculations;

namespace PaySpace.TaxCalculator.Tests
{
    [TestFixture]
    public class TaxCalculatorTests
    {
        [Test]
        public void TestProgressiveTax()
        {
            Assert.AreEqual(1000, Calculator.CalculateProgressiveTax(10000));
            Assert.AreEqual(5896.25, Calculator.CalculateProgressiveTax(40000));
            // Add more test cases as needed
        }

        [Test]
        public void TestFlatValueTax()
        {
            Assert.AreEqual(10000, Calculator.CalculateFlatValueTax(150000));
            Assert.AreEqual(7500, Calculator.CalculateFlatValueTax(120000));
            // Add more test cases as needed
        }

        [Test]
        public void TestFlatRateTax()
        {
            Assert.AreEqual(1750, Calculator.CalculateFlatRateTax(10000));
            Assert.AreEqual(2625, Calculator.CalculateFlatRateTax(15000));
            // Add more test cases as needed
        }

        [Test]
        public void TestCalculateTaxWithInvalidTaxType()
        {
            Assert.AreEqual(0, Calculator.CalculateTax(50000, "InvalidTaxType"));
        }
    }
}