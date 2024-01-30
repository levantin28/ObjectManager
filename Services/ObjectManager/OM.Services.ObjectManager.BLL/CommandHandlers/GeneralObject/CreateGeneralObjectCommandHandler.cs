using OM.Common.CQRS.Commands.Handler;
using OM.Services.ObjectManager.BLL.Commands.GeneralObjects;
using OM.Services.ObjectManager.DAL.Repositories.GeneralObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Services.ObjectManager.BLL.CommandHandlers.GeneralObject
{
    public class CreateGeneralObjectCommandHandler : ICommandHandler<CreateGeneralObjectCommand>
    {
        // Field to store the repository responsible for handling GeneralObject entities.
        private readonly IGeneralObjectRepository _generalObjectRepository;

        // Constructor to initialize the handler with the GeneralObject repository.
        public CreateGeneralObjectCommandHandler(IGeneralObjectRepository generalObjectRepository)
        {
            _generalObjectRepository = generalObjectRepository;
        }

        // Handles the CreateGeneralObjectCommand by adding or updating a GeneralObject in the repository.
        public async Task HandleAsync(CreateGeneralObjectCommand command)
        {
            // Create a GeneralObject based on the command and add or update it in the repository.
            await _generalObjectRepository.AddOrUpdateAsync(CreateGeneralObjectCommand.CreateGeneralObject(command));
        }
    }
}
