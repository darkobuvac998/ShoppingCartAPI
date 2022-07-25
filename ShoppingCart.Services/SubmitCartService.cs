using Newtonsoft.Json;
using ShoppingCart.Contracts.IServices;
using System.Net.Http.Json;
using System.Text;

namespace ShoppingCart.Services
{
    // Simple example of service for submitting cart to 3rd party system.
    // This service will be used in unit tests for testing cart submit action.
    public class SubmitCartService : ISubmitCartService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SubmitCartService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> SubmitCart(object preparedCartForSubmit)
        {
            var client = _httpClientFactory.CreateClient();
            var data = new StringContent(JsonConvert.SerializeObject(preparedCartForSubmit), Encoding.UTF8, "applications/json");

            var response = await client.PostAsync("https://shopping-cart.com/submit", data);
            var returnedObject = await response.Content.ReadFromJsonAsync<ResponseObject>();

            if (response.IsSuccessStatusCode && returnedObject.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class ResponseObject
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
