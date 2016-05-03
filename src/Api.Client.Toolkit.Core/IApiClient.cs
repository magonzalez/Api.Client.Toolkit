namespace Api.Client.Toolkit
{
    public interface IApiClient<TGetDataType, in TCreateDataType, in TUpdateDataType, in TKeyType> : IReadApiClient<TGetDataType, TKeyType>, IWriteApiClient<TGetDataType, TCreateDataType, TUpdateDataType, TKeyType>
    {
    }
}
