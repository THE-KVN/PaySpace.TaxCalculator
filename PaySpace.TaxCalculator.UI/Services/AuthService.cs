using Newtonsoft.Json;
using PaySpace.TaxCalculator.UI.Helpers;
using PaySpace.TaxCalculator.UI.Models;
using PaySpace.TaxCalculator.UI.Services.Interfaces;
using RestSharp;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace PaySpace.TaxCalculator.UI.Services
{
    public class AuthService : IAuthService
    {

        private readonly HttpClient _client;
        public AuthService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }


        public async Task<AuthToken> Login(LoginViewModel loginViewModel)
        {
            try
            {
                //Validation 
                var validation = ValidateRequest(loginViewModel);

                if (validation.Item1)
                {
                    var client = new RestClient($"{_client.BaseAddress}api/Users/login");
                    var restrequest = new RestRequest(Method.POST);
                    //var token = await GetToken().ConfigureAwait(false);
                    //restrequest.AddHeader("Authorization", $"bearer {token.access_token}");
                    restrequest.AddHeader("content-type", "application/json");

                    client.Timeout = 300000; //5 minutes 
                    restrequest.Timeout = 300000; //5 minutes 


                    restrequest.AddJsonBody(loginViewModel);
                    var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(loginViewModel);

                    IRestResponse restresponse = client.Execute(restrequest);
                    if (restresponse.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception($"Authorization failed : {restresponse.Content}");

                    }

                    var token = JsonConvert.DeserializeObject<AuthToken>(restresponse.Content);




                    return token;


                }
                else
                {
                    throw new Exception($"Validation failed");
                }


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
