using OM.Common.CQRS.Commands.Validator;
using OM.Common.Models.Validation;
using OM.Services.ObjectManager.BLL.Commands.Relations;
using OM.Services.ObjectManager.DAL.Repositories.Relations;

namespace OM.Services.ObjectManager.BLL.CommandValidators.Relations
{
    public class CreateRelationCommandValidator : ICommandValidator<CreateRelationCommand>
    {
        // Field to store the repository responsible for handling Relation entities.
        private readonly IRelationRepository _relationRepository;

        // Constructor to initialize the validator with the Relation repository.
        public CreateRelationCommandValidator(IRelationRepository relationRepository)
        {
            _relationRepository = relationRepository;
        }

        // Validates the CreateRelationCommand by checking if the specified relation can be created.
        public async Task<ValidationResultModel> ValidateAsync(CreateRelationCommand command)
        {
            // Check if the relation already exists between the specified parent and child objects.
            if (await _relationRepository.RelationExists(command.ParentObjectId, command.ChildObjectId))
            {
                // Return a validation result with an error message if the relation already exists.
                return new ValidationResultModel("This relation exists!");
            }

            // Check if the vice versa relation already exists (child to parent) between the specified objects.
            if (await _relationRepository.ViceversaRelationExists(command.ParentObjectId, command.ChildObjectId))
            {
                // Return a validation result with an error message if the vice versa relation already exists.
                return new ValidationResultModel("The vice versa relation already exists!");
            }

            // Return an empty validation result if the relation can be created.
            return new ValidationResultModel();
        }
    }
}
