namespace PaySpace.TaxCalculator.Domain
{
    public class UnsupportedPostCode : Exception
    {
        public UnsupportedPostCode(string code)
            : base($"Postcode \"{code}\" is unsupported.")
        {
        }
    }
}
