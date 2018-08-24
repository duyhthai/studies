using System;
using RestSharp;

namespace CurrencyExchange.Core
{
    public static class Utilities
    {
        public static IRestResponse ExecuteApi(string apiUrl, Method method = Method.GET)
        {
            var client = new RestClient(apiUrl);
            var request = new RestRequest(method);
            return client.Execute(request);
        }
    }
}
