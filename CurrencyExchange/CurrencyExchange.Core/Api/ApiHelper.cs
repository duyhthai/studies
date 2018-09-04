using RestSharp;

namespace CurrencyExchange.Core.Api
{
    public static class ApiHelper
    {
        public static IRestResponse ExecuteApi(string apiUrl, Method method = Method.GET)
        {
            var client = new RestClient(apiUrl);
            var request = new RestRequest(method);
            return client.Execute(request);
        }
    }
}
