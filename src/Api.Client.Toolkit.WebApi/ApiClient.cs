using System.Net.Http;
using System.Threading.Tasks;

namespace Api.Client.Toolkit.WebApi
{
    public abstract class ApiClient<TDataType, TKeyType> : ReadOnlyApiClient<TDataType, TKeyType>, IApiClient<TDataType, TKeyType>
    {
        protected ApiClient(IApiClientSettings settings, string baseUrl)
            : base(settings, baseUrl)
        {
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
