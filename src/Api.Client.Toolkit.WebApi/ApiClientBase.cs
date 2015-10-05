using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Api.Client.Toolkit.WebApi
{
    public class ApiClientBase : IApiClientBase
    {
        private readonly object _syncObject = new object();
        private HttpClient _clientInstance;

        protected ApiClientBase(IApiClientSettings settings)
        {
            Settings = settings;
        }

        protected IApiClientSettings Settings { get; private set; }

        protected virtual HttpClient Client
        {
            get
            {
                var client = _clientInstance;
                if (client != null)
                    return client;

                lock (_syncObject)
                {
                    client = _clientInstance;
                    if (client != null)
                        return client;

                    client = CreateHttpClient();

                    _clientInstance = client;
                }

                return client;
            }
        }

        public void Dispose()
        {
            _clientInstance.Dispose();
            _clientInstance = null;
        }

        protected virtual HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            ConfigureHttpClient(client);

            return client;
        }

        protected virtual void ConfigureHttpClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.BaseAddress = new Uri(Settings.ApiBaseUri);
        }
    }
}
