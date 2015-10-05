using System.Threading.Tasks;

namespace Api.Client.Toolkit.Authentication
{
    public interface IApiClientAuthenticator
    {
        Task<IApiClientAuthenticationResult> Authenticate();
    }
}
