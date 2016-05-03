using System.Threading.Tasks;

namespace Api.Client.Toolkit
{
    public interface IWriteApiClient<TGetDataType, in TCreateDataType, in TUpdateDataType, in TKeyType> : IApiClientBase
    {
        Task<TGetDataType> Create(TCreateDataType data);
        Task<TGetDataType> Update(TKeyType id, TUpdateDataType data);
        Task Delete(TKeyType id);
    }
}
