using Microsoft.EntityFrameworkCore;
using PaySpace.TaxCalculator.Domain;

namespace PaySpace.TaxCalculator.Application
{
    public interface IApplicationDbContext
    {
        DbSet<TaxCalculationEntity> TaxCalculations { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
