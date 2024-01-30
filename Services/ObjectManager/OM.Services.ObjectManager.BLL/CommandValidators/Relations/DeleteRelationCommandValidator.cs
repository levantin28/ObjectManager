using OM.Common.CQRS.Commands.Validator;
using OM.Common.Models.Validation;
using OM.Services.ObjectManager.BLL.Commands.Relations;
using OM.Services.ObjectManager.DAL.Repositories.Relations;

namespace OM.Services.ObjectManager.BLL.CommandValidators.Relations
{
    public class DeleteRelationCommandValidator : ICommandValidator<DeleteRelationCommand>
    {
        // Field to store the repository responsible for handling Relation entities.
        private readonly IRelationRepository _relationRepository;

        // Constructor to initialize the validator with the Relation repository.
        public DeleteRelationCommandValidator(IRelationRepository relationRepository)
        {
            _relationRepository = relationRepository;
        }

        // Validates the DeleteRelationCommand by checking if the specified relation can be deleted.
        public async Task<ValidationResultModel> ValidateAsync(DeleteRelationCommand command)
        {
            // Check if a Relation with the specified ID exists in the repository.
            if (await _relationRepository.GetAsync(command.Id) == null)
            {
                // Return a validation result with an error message if the record doesn't exist.
                return new ValidationResultModel("Record doesn't exist!");
            }

            // Return an empty validation result if the relation can be deleted.
            return new ValidationResultModel();
        }
    }
}
