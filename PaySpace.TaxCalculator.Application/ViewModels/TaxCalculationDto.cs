using AutoMapper;
using PaySpace.TaxCalculator.Domain;

namespace PaySpace.TaxCalculator.Application
{
    public class TaxCalculationDto
    {
        public Guid Id { get; init; }
        public DateTimeOffset Created { get; set; }
        public Guid CreatedBy { get; set; }
        public decimal AnualIncome { get; set; }
        public string PostalCode { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TakeHomeIncome { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<TaxCalculationEntity, TaxCalculationDto>();
            }
        }
    }
}
