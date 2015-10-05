using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Client.Toolkit
{
    public interface IReadApiClient<TDataType, in TKeyType> : IApiClientBase
    {
        Task<IEnumerable<TDataType>> Get();
        Task<TDataType> Get(TKeyType id);
    }
}
