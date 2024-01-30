namespace OM.Common.CQRS.Queries.Handler
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : OMQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
