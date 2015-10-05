using System.Net.Http;
using System.Net.Http.Headers;
using Api.Client.Toolkit.Authentication;

namespace Api.Client.Toolkit.WebApi.Authentication.OAuth2
{
    public class OAuth2ApiClient<TDataType, TKeyType> : ApiClient<TDataType, TKeyType> where TDataType : class
    {
        private readonly IApiClientAuthenticator _authenticator;

        public OAuth2ApiClient(IApiClientAuthenticator authenticator, IApiClientSettings settings, string baseUrl)
            : base(settings, baseUrl)
        {
            _authenticator = authenticator;
        }

        protected IApiClientAuthenticationResult AuthenticationResult { get; set; }

        protected override HttpClient CreateHttpClient()
        {
            AuthenticationResult = _authenticator.Authenticate().Result;
            var client = base.CreateHttpClient();

            client.DefaultRequestHeaders.Add("token_type", "bearer");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationResult.ToString());

            return client;
        }
    }
}
