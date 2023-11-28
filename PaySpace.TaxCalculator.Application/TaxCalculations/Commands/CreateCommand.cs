using MediatR;
using PaySpace.TaxCalculator.Application.TaxCalculations;
using PaySpace.TaxCalculator.Domain;

namespace PaySpace.TaxCalculator.Application
{
    public record CreateCommand : IRequest<decimal>
    {
        public decimal AnualIncome { get; init; }
        public string PostalCode { get; init; }

    }

    public class CreateHandler : IRequestHandler<CreateCommand, decimal>
    {
        private readonly IApplicationDbContext _context;
        private readonly IUser _currentUser;

        public CreateHandler(IApplicationDbContext context, IUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<decimal> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            Guid userId = new Guid(_currentUser.Id);

            decimal taxAmount = (decimal)Calculator.CalculateTax(Decimal.ToDouble(request.AnualIncome), request.PostalCode);
            //Todo

            var entity = new TaxCalculationEntity
            {
                AnualIncome = request.AnualIncome,
                PostalCode = request.PostalCode,
                CreatedBy = userId,
                Created = DateTime.Now,
                TakeHomeIncome = 0M,
                TaxAmount = taxAmount
            };
            //
            //entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

            _context.TaxCalculations.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.TaxAmount;
        }


    }
}

