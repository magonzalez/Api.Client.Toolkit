namespace Api.Client.Toolkit
{
    public interface IApiClientFactory
    {
        IApiClient<TDataType, TKeyType> CreateClient<TDataType, TKeyType>(ApiClientType type);
    }
}
