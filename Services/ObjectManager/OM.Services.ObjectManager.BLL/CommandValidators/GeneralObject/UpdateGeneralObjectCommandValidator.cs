using OM.Common.CQRS.Commands.Validator;
using OM.Common.Models.Validation;
using OM.Services.ObjectManager.BLL.Commands.GeneralObjects;
using OM.Services.ObjectManager.DAL.Repositories.GeneralObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Services.ObjectManager.BLL.CommandValidators.GeneralObject
{
    public class UpdateGeneralObjectCommandValidator : ICommandValidator<UpdateGeneralObjectCommand>
    {
        // Field to store the repository responsible for handling GeneralObject entities.
        private readonly IGeneralObjectRepository _generalObjectRepository;

        // Constructor to initialize the validator with the GeneralObject repository.
        public UpdateGeneralObjectCommandValidator(IGeneralObjectRepository generalObjectRepository)
        {
            _generalObjectRepository = generalObjectRepository;
        }

        // Validates the UpdateGeneralObjectCommand by checking if the specified GeneralObject can be updated.
        public async Task<ValidationResultModel> ValidateAsync(UpdateGeneralObjectCommand command)
        {
            // Retrieve all GeneralObjects without tracking changes to the entities.
            var generalObjects = await _generalObjectRepository.GetAsync(asNoTracking: true);

            // Check if a GeneralObject with the specified ID exists in the repository.
            if (generalObjects.FirstOrDefault(x => x.Id == command.Id) == null)
            {
                // Return a validation result with an error message if the record doesn't exist.
                return new ValidationResultModel("Record doesn't exist!");
            }

            // Check if another GeneralObject with the same name already exists (excluding the current entity being updated).
            if (generalObjects.FirstOrDefault(x => x.Name == command.Name && x.Id != command.Id) != null)
            {
                // Return a validation result with an error message if the name already exists.
                return new ValidationResultModel("Name already exists!");
            }

            // Return an empty validation result if the update is valid.
            return new ValidationResultModel();
        }
    }
}
