using RestSharp.Authenticators;
using RestSharp;
using System.Net.Http.Headers;

namespace APIProvider.Classes
{
    public class RestHelper
    {
        private readonly RestClient client;

        public void AddDefaultHeader(string key, string value)
        {
            client.AddDefaultHeader(key, value);
        }

        public RestHelper(string url, string username, string password)
        {
            var options = new RestClientOptions(url)
            {
                Authenticator = new HttpBasicAuthenticator(username, password)
            };

            client = new RestClient(options);
        }
        public RestHelper(string url, string bearerToken)
        {
            var options = new RestClientOptions(url)
            {
                Authenticator = new JwtAuthenticator(bearerToken)
            };
            client = new RestClient(options);
        }

        public RestHelper(string url)
        {
            var options = new RestClientOptions(url);
            client = new RestClient(options);
        }
        public RestResponse DoRequest(Method method, string endpoint, string? body = null, string dataType = "json", string? bearerToken = null)
        {
            RestRequest request = new RestRequest(endpoint, method)
            {
                Authenticator = bearerToken != null ? new JwtAuthenticator(bearerToken!) : null
            };

            if (!string.IsNullOrWhiteSpace(body))
            {
                request.AddHeader("Content-Type", $"application/{dataType}");
                request.AddParameter($"application/{dataType}", body!, ParameterType.RequestBody);
            };

            try
            {
                return client.Execute(request);
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException("Request failed with the following error: " + e.Message);
            }
        }
    }
}