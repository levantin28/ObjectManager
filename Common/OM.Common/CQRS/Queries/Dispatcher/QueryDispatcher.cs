using OM.Common.CQRS.Queries.Handler;
using OM.Common.Extensions;

namespace OM.Common.CQRS.Queries.Dispatcher
{
    public class QueryDispatcher : IQueryDispatcher
    {
        // Field to store an instance of the service provider.
        private readonly IServiceProvider _serviceProvider;

        // Constructor to initialize the dispatcher with the necessary dependency.
        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // Method to dispatch a query asynchronously and return the result.
        public async Task<TResult> DispatchAsync<TResult>(OMQuery<TResult> query)
        {
            // Create the type of the expected query handler using reflection.
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            // Retrieve the appropriate query handler from the service provider.
            var handler = _serviceProvider.GetService(handlerType);

            // Invoke the HandleAsync method on the query handler and store the result.
            var result = await handler.InvokeAsync(handler, "HandleAsync", query);

            // Cast and return the result as the expected TResult type.
            return (TResult)result;
        }
    }
}
