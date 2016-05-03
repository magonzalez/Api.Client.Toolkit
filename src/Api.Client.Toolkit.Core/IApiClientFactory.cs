namespace Api.Client.Toolkit
{
    public interface IApiClientFactory
    {
        IApiClient<TDataType, TDataType, TDataType, TKeyType> CreateClient<TDataType, TKeyType>(ApiClientType type);
    }
}
