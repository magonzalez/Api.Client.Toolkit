using System.Net.Http;
using System.Threading.Tasks;

namespace Api.Client.Toolkit.WebApi
{
    public abstract class ApiClient<TDataType, TKeyType> : ApiClient<TDataType, TDataType, TDataType, TKeyType>
    {
        protected ApiClient(IApiClientSettings settings, string baseUrl)
            : base(settings, baseUrl)
        {
        }
    }

    public abstract class ApiClient<TGetDataType, TCreateDataType, TUpdateDataType, TKeyType> :
        ReadOnlyApiClient<TGetDataType, TKeyType>, IApiClient<TGetDataType, TCreateDataType, TUpdateDataType, TKeyType>
    {
        protected ApiClient(IApiClientSettings settings, string baseUrl)
            : base(settings, baseUrl)
        {
        }

        public virtual async Task<TGetDataType> Create(TCreateDataType data)
        {
            var response = await Client.PostAsJsonAsync(BaseUrl, data);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<TGetDataType>();

            return default(TGetDataType);
        }

        public virtual async Task<TGetDataType> Update(TKeyType id, TUpdateDataType data)
        {
            var response = await Client.PutAsJsonAsync($"{BaseUrl}/{id}", data);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<TGetDataType>();

            return default(TGetDataType);
        }

        public virtual async Task Delete(TKeyType id)
        {
            await Client.DeleteAsync($"{BaseUrl}/{id}");
        }
    }
}
