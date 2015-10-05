using System.Net.Http;
using Api.Client.Toolkit.Authentication.ApiKey;

namespace Api.Client.Toolkit.WebApi.Authentication.ApiKey
{
    public class ApiKeyApiClient<TDataType, TKeyType> : ApiClient<TDataType, TKeyType> where TDataType : class
    {
        public ApiKeyApiClient(IApiKeyApiClientSettings settings, string baseUrl)
            : base(settings, baseUrl)
        {
        }

        protected override HttpClient CreateHttpClient()
        {
            var client = base.CreateHttpClient();

            client.DefaultRequestHeaders.Add("Authorization", ((IApiKeyApiClientSettings)Settings).ApiKey);

            return client;
        }
    }
}
