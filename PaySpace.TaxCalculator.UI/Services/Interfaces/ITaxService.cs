using PaySpace.TaxCalculator.UI.Models;

namespace PaySpace.TaxCalculator.UI.Services.Interfaces
{
    public interface ITaxService
    {
        PaginatedResponse<TaxCalculationHistoryViewModel> GetTaxCalculations(string token);
        decimal CreateTaxCalculation(string token, decimal income, string postalcode);
    }
}
