using OM.Common.Models.Validation;

namespace OM.Common.CQRS.Commands.Validator
{
    public abstract class CommandValidator<TCommand> : ICommandValidator<TCommand>
        where TCommand : OMCommand
    {
        public abstract Task<ValidationResultModel> ValidateAsync(TCommand command);
    }
}
