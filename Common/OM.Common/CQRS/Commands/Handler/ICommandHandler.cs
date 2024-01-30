namespace OM.Common.CQRS.Commands.Handler
{
    public interface ICommandHandler<TCommand>
        where TCommand : OMCommand
    {
        Task HandleAsync(TCommand command);
    }
}
