using System.Threading.Tasks;

namespace Api.Client.Toolkit
{
    public interface IWriteApiClient<TDataType, in TKeyType> : IApiClientBase
    {
        Task<TDataType> Create(TDataType data);
        Task<TDataType> Update(TKeyType id, TDataType data);
        Task Delete(TKeyType id);
    }
}
