using MediatR;
using PaySpace.TaxCalculator.API.Infrastructure;
using PaySpace.TaxCalculator.Application;

namespace PaySpace.TaxCalculator.API.Endpoints
{
    public class TaxCalculations : EndpointGroupBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaxCalculations()
        {

        }
        public TaxCalculations(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .RequireAuthorization()
                .MapGet(GetTaxCalculations)
                .MapPost(CreateTaxCalculation);
            //.MapPut(UpdateTodoItem, "{id}")
            //.MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            //.MapDelete(DeleteTodoItem, "{id}");
        }

        public async Task<PaginatedList<TaxCalculationDto>> GetTaxCalculations(ISender sender, [AsParameters] GetTaxCalculationsCommand query)
        {
            return await sender.Send(query);
        }

        public async Task<decimal> CreateTaxCalculation(ISender sender, CreateCommand command)
        {
            return await sender.Send(command);
        }

        //public async Task<IResult> UpdateTodoItem(ISender sender, int id, UpdateTodoItemCommand command)
        //{
        //    if (id != command.Id) return Results.BadRequest();
        //    await sender.Send(command);
        //    return Results.NoContent();
        //}

        //public async Task<IResult> UpdateTodoItemDetail(ISender sender, int id, UpdateTodoItemDetailCommand command)
        //{
        //    if (id != command.Id) return Results.BadRequest();
        //    await sender.Send(command);
        //    return Results.NoContent();
        //}

        //public async Task<IResult> DeleteTodoItem(ISender sender, int id)
        //{
        //    await sender.Send(new DeleteTodoItemCommand(id));
        //    return Results.NoContent();
        //}
    }
}
