using Api.Client.Toolkit.Authentication.ApiKey;

namespace Api.Client.Toolkit.WebApi
{
    public abstract class ApiClientFactory : IApiClientFactory
    {
        protected ApiClientFactory(IApiKeyApiClientSettings settings)
        {
            Settings = settings;
        }

        protected IApiKeyApiClientSettings Settings { get; private set; }

        public abstract IApiClient<TDataType, TKeyType> CreateClient<TDataType, TKeyType>(ApiClientType type);
    }
}
