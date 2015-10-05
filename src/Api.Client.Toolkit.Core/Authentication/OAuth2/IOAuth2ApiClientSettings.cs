namespace Api.Client.Toolkit.Authentication.OAuth2
{
    public interface IOAuth2ApiClientSettings : IApiClientSettings
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
