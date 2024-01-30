using OM.Common.Models.Validation;

namespace OM.Common.CQRS.Commands.Dispatcher
{
    public interface ICommandDispatcher
    {
        Task<ValidationResultModel> DispatchAsync<TCommand>(TCommand command) where TCommand : OMCommand;
    }
}
