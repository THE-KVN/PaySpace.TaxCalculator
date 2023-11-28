using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace PaySpace.TaxCalculator.Application
{
    public record GetTaxCalculationsCommand : IRequest<PaginatedList<TaxCalculationDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetTaxCalculationsHandler : IRequestHandler<GetTaxCalculationsCommand, PaginatedList<TaxCalculationDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUser _currentUser;

        public GetTaxCalculationsHandler(IApplicationDbContext context, IMapper mapper, IUser currentUser)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<PaginatedList<TaxCalculationDto>> Handle(GetTaxCalculationsCommand request, CancellationToken cancellationToken)
        {
            Guid userId = new Guid(_currentUser.Id);


            //return await _context.TaxCalculations
            //    .Where(x => x.CreatedBy == userId)
            //    .OrderBy(x => x.Created)
            //    .ProjectTo<TaxCalculationDto>(_mapper.ConfigurationProvider)
            //    .PaginatedListAsync(request.PageNumber, request.PageSize);

            return await _context.TaxCalculations
                .ProjectTo<TaxCalculationDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
