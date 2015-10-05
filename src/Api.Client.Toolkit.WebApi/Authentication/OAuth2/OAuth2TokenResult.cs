using Api.Client.Toolkit.Authentication;

namespace Api.Client.Toolkit.WebApi.Authentication.OAuth2
{
    public class OAuth2TokenResult : IApiClientAuthenticationResult
    {
        public string token_type { get; set; }
        public string access_token { get; set; }

        public override string ToString()
        {
            return access_token;
        }
    }
}
