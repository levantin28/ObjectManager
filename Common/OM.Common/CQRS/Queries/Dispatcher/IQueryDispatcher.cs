namespace OM.Common.CQRS.Queries.Dispatcher
{
    public interface IQueryDispatcher
    {
        Task<TResult> DispatchAsync<TResult>(OMQuery<TResult> query);
    }
}
