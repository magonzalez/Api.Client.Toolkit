namespace Api.Client.Toolkit.Authentication.ApiKey
{
    public interface IApiKeyApiClientSettings : IApiClientSettings
    {
        string ApiKey { get; set; }
    }
}
