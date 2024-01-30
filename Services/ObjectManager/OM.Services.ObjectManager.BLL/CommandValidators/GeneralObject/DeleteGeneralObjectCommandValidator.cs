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
    public class DeleteGeneralObjectCommandValidator : ICommandValidator<DeleteGeneralObjectCommand>
    {
        // Field to store the repository responsible for handling GeneralObject entities.
        private readonly IGeneralObjectRepository _generalObjectRepository;

        // Constructor to initialize the validator with the GeneralObject repository.
        public DeleteGeneralObjectCommandValidator(IGeneralObjectRepository generalObjectRepository)
        {
            _generalObjectRepository = generalObjectRepository;
        }

        // Validates the DeleteGeneralObjectCommand by checking if a GeneralObject with the specified ID exists.
        public async Task<ValidationResultModel> ValidateAsync(DeleteGeneralObjectCommand command)
        {
            // Check if a GeneralObject with the specified ID exists in the repository.
            if (await _generalObjectRepository.GetAsync(command.Id) == null)
            {
                // Return a validation result with an error message if the record doesn't exist.
                return new ValidationResultModel("Record doesn't exist!");
            }

            // Return an empty validation result if the record exists.
            return new ValidationResultModel();
        }
    }
}
