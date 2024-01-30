using OM.Common.CQRS.Commands.Validator;
using OM.Common.Models.Validation;
using OM.Services.ObjectManager.BLL.Commands.Relations;
using OM.Services.ObjectManager.DAL.Repositories.Relations;

namespace OM.Services.ObjectManager.BLL.CommandValidators.Relations
{
    public class UpdateRealtionCommandValidator : ICommandValidator<UpdateRelationCommand>
    {
        // Field to store the repository responsible for handling Relation entities.
        private readonly IRelationRepository _relationRepository;

        // Constructor to initialize the validator with the Relation repository.
        public UpdateRealtionCommandValidator(IRelationRepository relationRepository)
        {
            _relationRepository = relationRepository;
        }

        // Validates the UpdateRelationCommand by checking if the specified relation can be updated.
        public async Task<ValidationResultModel> ValidateAsync(UpdateRelationCommand command)
        {
            // Retrieve all relations without tracking changes to the entities.
            var relations = await _relationRepository.GetAsync(asNoTracking: true);

            // Check if a Relation with the specified ID exists in the repository.
            if (relations.FirstOrDefault(x => x.Id == command.Id) == null)
            {
                // Return a validation result with an error message if the record doesn't exist.
                return new ValidationResultModel("Record doesn't exist!");
            }

            // Check if the new relation already exists between the specified parent and child objects.
            if (await _relationRepository.RelationExists(command.ParentObjectId, command.ChildObjectId))
            {
                // Return a validation result with an error message if the relation already exists.
                return new ValidationResultModel("This relation already exists!");
            }

            // Check if the vice versa relation already exists (child to parent) between the specified objects.
            if (await _relationRepository.ViceversaRelationExists(command.ParentObjectId, command.ChildObjectId))
            {
                // Return a validation result with an error message if the vice versa relation already exists.
                return new ValidationResultModel("The vice versa relation already exists!");
            }

            // Return an empty validation result if the update is valid.
            return new ValidationResultModel();
        }
    }
}
