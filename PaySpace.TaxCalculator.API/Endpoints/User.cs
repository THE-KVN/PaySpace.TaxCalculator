using PaySpace.TaxCalculator.API.Infrastructure;
using PaySpace.TaxCalculator.Infrastructure;

namespace PaySpace.TaxCalculator.API.Endpoints
{
    public class Users : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .MapIdentityApi<ApplicationUser>();
        }
    }
}
