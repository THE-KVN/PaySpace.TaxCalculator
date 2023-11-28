using Newtonsoft.Json;
using PaySpace.TaxCalculator.UI.Models;
using PaySpace.TaxCalculator.UI.Services.Interfaces;
using RestSharp;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace PaySpace.TaxCalculator.UI.Services
{
    public class TaxService : ITaxService
    {

        private readonly HttpClient _client;
        public TaxService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }


        public PaginatedResponse<TaxCalculationHistoryViewModel> GetTaxCalculations(string token)
        {
            try
            {
                var client = new RestClient($"{_client.BaseAddress}api/TaxCalculations?PageNumber=1&PageSize=1000");
                var restrequest = new RestRequest(Method.GET);
                restrequest.AddHeader("Authorization", $"{token}");
                restrequest.AddHeader("content-type", "application/json");

                client.Timeout = 300000; //5 minutes 
                restrequest.Timeout = 300000; //5 minutes 

                IRestResponse restresponse = client.Execute(restrequest);
                if (restresponse.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception($"Request failed : {restresponse.Content}");

                }

                var result = JsonConvert.DeserializeObject<PaginatedResponse<TaxCalculationHistoryViewModel>>(restresponse.Content);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception($"Authorization failed : {ex.Message}");
            }
        }
        public decimal CreateTaxCalculation(string token, decimal income, string postalcode)
        {
            try
            {
                var client = new RestClient($"{_client.BaseAddress}api/TaxCalculations");
                var restrequest = new RestRequest(Method.POST);
                restrequest.AddHeader("Authorization", $"{token}");
                restrequest.AddHeader("content-type", "application/json");

                client.Timeout = 300000; //5 minutes 
                restrequest.Timeout = 300000; //5 minutes 

                dynamic request = new System.Dynamic.ExpandoObject();
                request.AnualIncome = income;
                request.PostalCode = postalcode;


                restrequest.AddJsonBody(request);
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(request);

                IRestResponse restresponse = client.Execute(restrequest);
                if (restresponse.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception($"Request failed : {restresponse.Content}");

                }

                var result = JsonConvert.DeserializeObject<decimal>(restresponse.Content);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception($"Authorization failed : {ex.Message}");
            }
        }

        private Tuple<bool, string> ValidateRequest(object request)
        {
            ValidationContext validationContext = new ValidationContext(request);

            // A list to hold the validation result.
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(request, validationContext, results, true))
            {
                StringBuilder sb = new StringBuilder();
                foreach (var errors in results)
                {
                    sb.AppendLine(errors.ErrorMessage);
                }

                return new Tuple<bool, string>(false, sb.ToString());

            }
            else
            {
                return new Tuple<bool, string>(true, string.Empty);
            }
        }
    }
}
