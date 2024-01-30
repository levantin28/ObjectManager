namespace OM.Common.CQRS.Commands.Handler
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : OMCommand
    {
        public abstract Task HandleAsync(TCommand command);
    }
}
