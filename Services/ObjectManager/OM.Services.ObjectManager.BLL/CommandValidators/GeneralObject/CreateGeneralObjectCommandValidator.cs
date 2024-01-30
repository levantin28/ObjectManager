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
    public class CreateGeneralObjectCommandValidator : ICommandValidator<CreateGeneralObjectCommand>
    {
        // Field to store the repository responsible for handling GeneralObject entities.
        private readonly IGeneralObjectRepository _generalObjectRepository;

        // Constructor to initialize the validator with the GeneralObject repository.
        public CreateGeneralObjectCommandValidator(IGeneralObjectRepository generalObjectRepository)
        {
            _generalObjectRepository = generalObjectRepository;
        }

        // Validates the CreateGeneralObjectCommand by checking if a GeneralObject with the same name already exists.
        public async Task<ValidationResultModel> ValidateAsync(CreateGeneralObjectCommand command)
        {
            // Check if a GeneralObject with the specified name already exists in the repository.
            if (await _generalObjectRepository.GetGeneralObjectByName(command.Name) != null)
            {
                // Return a validation result with an error message if the record already exists.
                return new ValidationResultModel("Record already exists!");
            }

            // Return an empty validation result if the record does not already exist.
            return new ValidationResultModel();
        }
    }
}
