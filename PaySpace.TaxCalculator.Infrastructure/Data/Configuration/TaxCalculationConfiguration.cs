using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaySpace.TaxCalculator.Domain;

namespace PaySpace.TaxCalculator.Infrastructure.Data.Configuration
{
    public class TaxCalculationConfiguration : IEntityTypeConfiguration<TaxCalculationEntity>
    {
        public void Configure(EntityTypeBuilder<TaxCalculationEntity> builder)
        {
            builder.Property(t => t.AnualIncome)
                .IsRequired();

            builder.Property(t => t.PostalCode)
                .IsRequired();
        }
    }
}
