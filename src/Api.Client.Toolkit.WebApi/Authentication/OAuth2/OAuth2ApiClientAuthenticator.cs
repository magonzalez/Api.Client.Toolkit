using System;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Client.Toolkit.Authentication;
using Api.Client.Toolkit.Authentication.OAuth2;

namespace Api.Client.Toolkit.WebApi.Authentication.OAuth2
{
    public class OAuth2ApiClientAuthenticator : ApiClientBase, IApiClientAuthenticator
    {
        private readonly IOAuth2ApiClientSettings _settings;

        public OAuth2ApiClientAuthenticator(IOAuth2ApiClientSettings settings)
            : base(settings)
        {
            _settings = settings;
        }

        public virtual async Task<IApiClientAuthenticationResult> Authenticate()
        {
            var response = await Client.PostAsync("Authenticate", GetContent());
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(string.Format("Authentication failed - {0} {1}",
                    response.StatusCode, response.ReasonPhrase));
            }

            return await response.Content.ReadAsAsync<OAuth2TokenResult>();
        }

        protected override void ConfigureHttpClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("username", new[] { _settings.Username });
            client.DefaultRequestHeaders.Add("password", new[] { _settings.Password });
            client.DefaultRequestHeaders.Add("grant_type", new[] { "password" });
        }

        protected virtual HttpContent GetContent()
        {
            return new StringContent("");
        }
    }
}
