using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.Client.Toolkit.WebApi
{
    public abstract class ApiClient<TDataType, TKeyType> : ApiClientBase, IApiClient<TDataType, TKeyType>
    {
        protected ApiClient(IApiClientSettings settings, string baseUrl)
            : base(settings)
        {
            BaseUrl = string.Format("{0}/{1}", settings.ApiBaseUri, baseUrl);
        }

        protected string BaseUrl { get; set; }

        public virtual async Task<IEnumerable<TDataType>> Get()
        {
            var response = await Client.GetAsync(BaseUrl);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<IEnumerable<TDataType>>();

            return new List<TDataType>();
        }

        public virtual async Task<TDataType> Get(TKeyType id)
        {
            var uri = string.Format("{0}/{1}", BaseUrl, id);

            var response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<TDataType>();

            return default(TDataType);
        }

        public virtual async Task<TDataType> Create(TDataType data)
        {
            var response = await Client.PostAsJsonAsync(BaseUrl, data);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<TDataType>();

            return default(TDataType);
        }

        public virtual async Task<TDataType> Update(TKeyType id, TDataType data)
        {

            var uri = string.Format("{0}/{1}", BaseUrl, id);

            var response = await Client.PutAsJsonAsync(uri, data);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<TDataType>();

            return default(TDataType);
        }

        public virtual async Task Delete(TKeyType id)
        {
            var uri = string.Format("{0}/{1}", BaseUrl, id);

            await Client.DeleteAsync(uri);
        }
    }
}
