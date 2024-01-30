using OM.Common.Models.Validation;

namespace OM.Common.CQRS.Commands.Validator
{
    public interface ICommandValidator<TCommand>
        where TCommand : OMCommand
    {
        Task<ValidationResultModel> ValidateAsync(TCommand command);
    }
}
