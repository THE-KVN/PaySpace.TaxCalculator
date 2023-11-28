using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PaySpace.TaxCalculator.UI.Helpers;
using PaySpace.TaxCalculator.UI.Models;
using PaySpace.TaxCalculator.UI.Services.Interfaces;
using System.Security.Claims;

namespace PaySpace.TaxCalculator.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public LoginController(IAuthService service, IHttpContextAccessor httpContextAccessor)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                AuthToken token;
                try
                {
                    token = await _service.Login(model);
                }
                catch (Exception ex)
                {
                    model.isvalid = false;
                    return View(model);
                }


                AuthenticationProperties options = new AuthenticationProperties();

                options.AllowRefresh = true;
                options.IsPersistent = true;
                options.ExpiresUtc = DateTime.UtcNow.AddSeconds(token.expiresIn);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, model.email),
                    new Claim("AcessToken", string.Format("Bearer {0}", token.accessToken)),
                };

                var identity = new ClaimsIdentity(claims, "ApplicationCookie");

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    options);

                return RedirectToAction("CalculateTax", "Tax");
            }

            // If we reach here, the model is not valid. Re-render the view with validation errors.
            return View(model);



        }
    }
}
