using System.Configuration;

namespace Api.Client.Toolkit.Authentication.ApiKey
{
    public class ApiKeyApiClientSettings : ApiClientSettings, IApiKeyApiClientSettings
    {
        public ApiKeyApiClientSettings()
        {
            ApiKey = ConfigurationManager.AppSettings["ApiKey"];

            if(string.IsNullOrWhiteSpace(ApiKey))
                throw new ConfigurationErrorsException("AppSettings[ApiKey] is not configured!");
        }

        public string ApiKey { get; set; }
    }
}
