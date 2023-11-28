namespace PaySpace.TaxCalculator.Domain
{
    public class TaxCalculationEntity : BaseEntity
    {
        public decimal AnualIncome { get; set; }
        public string PostalCode { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TakeHomeIncome { get; set; }
    }
}
