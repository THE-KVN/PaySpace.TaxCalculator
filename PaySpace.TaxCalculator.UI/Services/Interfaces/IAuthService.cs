using PaySpace.TaxCalculator.UI.Helpers;
using PaySpace.TaxCalculator.UI.Models;

namespace PaySpace.TaxCalculator.UI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthToken> Login(LoginViewModel loginViewModel);
    }
}
