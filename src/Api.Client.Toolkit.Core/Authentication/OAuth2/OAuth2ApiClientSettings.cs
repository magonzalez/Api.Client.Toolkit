using System.Configuration;

namespace Api.Client.Toolkit.Authentication.OAuth2
{
    public class OAuth2ApiClientSettings : ApiClientSettings, IOAuth2ApiClientSettings
    {
        public OAuth2ApiClientSettings()
        {
            Username = ConfigurationManager.AppSettings["ApiUserName"];
            if (string.IsNullOrWhiteSpace(Username))
                throw new ConfigurationErrorsException("AppSettings[ApiUserName] is not configured!");

            Password = ConfigurationManager.AppSettings["ApiPassword"];
            if (string.IsNullOrWhiteSpace(Password))
                throw new ConfigurationErrorsException("AppSettings[ApiPassword] is not configured!");
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
