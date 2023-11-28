using Microsoft.AspNetCore.Mvc.Rendering;
using PaySpace.TaxCalculator.UI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace PaySpace.TaxCalculator.UI.Models
{
    public class TaxCalculationViewModel
    {
        private AuthToken authToken { get; set; }
        [Required]
        public decimal AnualIncome { get; set; }
        [Required]
        public string PostalCode { get; set; }

        public List<SelectListItem> PostalCodes { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal TakeHomeIncome { get; set; }

        public List<TaxCalculationHistoryViewModel> History { get; set; }

        public TaxCalculationViewModel()
        {
            TaxAmount = null;
            History = new List<TaxCalculationHistoryViewModel>();
            PostalCodes = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "7441", Value = "7441"},
                new SelectListItem() {Text = "A100", Value = "A100"},
                new SelectListItem() {Text = "7000", Value = "7000"},
                new SelectListItem() {Text = "1000", Value = "1000"}
            };
        }
    }

    public class TaxCalculationHistoryViewModel
    {
        public Guid id { get; set; }
        public DateTimeOffset created { get; set; }
        public Guid createdBy { get; set; }
        public decimal anualIncome { get; set; }
        public string postalCode { get; set; }
        public decimal taxAmount { get; set; }
        public decimal takeHomeIncome { get; set; }
    }
}

