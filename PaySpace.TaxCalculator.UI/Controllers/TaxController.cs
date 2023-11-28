using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaySpace.TaxCalculator.UI.Models;
using PaySpace.TaxCalculator.UI.Services.Interfaces;
using System.Security.Claims;

namespace PaySpace.TaxCalculator.UI.Controllers
{
    [Authorize]
    public class TaxController : Controller
    {

        private readonly ITaxService _taxService;

        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }


        [HttpGet]
        public ActionResult CalculateTax()
        {
            var token = ((ClaimsPrincipal)HttpContext.User).FindFirst("AcessToken").Value;
            var history = _taxService.GetTaxCalculations(token);
            var viewModel = new TaxCalculationViewModel();
            viewModel.History = history.items.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CalculateTax(TaxCalculationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Perform tax calculation logic here
                var token = ((ClaimsPrincipal)HttpContext.User).FindFirst("AcessToken").Value;
                model.TaxAmount = _taxService.CreateTaxCalculation(token, model.AnualIncome, model.PostalCode);
                var history = _taxService.GetTaxCalculations(token);
                model.History = history.items.ToList();
                return View(model);
            }

            // If we reach here, the model is not valid. Re-render the view with validation errors.
            return View(model);
        }
    }
}
