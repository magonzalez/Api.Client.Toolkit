namespace Api.Client.Toolkit
{
    public interface IApiClient<TDataType, in TKeyType> : IReadApiClient<TDataType, TKeyType>, IWriteApiClient<TDataType, TKeyType>
    {
    }
}
