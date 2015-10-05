using System.Configuration;

namespace Api.Client.Toolkit
{
    public class ApiClientSettings
    {
        public ApiClientSettings()
        {
            ApiBaseUri = ConfigurationManager.AppSettings["Api.Client.Toolkit.ApiBaseUri"]
                ?? string.Empty;
        }

        public string ApiBaseUri { get; set; }
    }
}
