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
    public class UpdateGeneralObjectCommandHandler : ICommandHandler<UpdateGeneralObjectCommand>
    {
        // Field to store the repository responsible for handling GeneralObject entities.
        private readonly IGeneralObjectRepository _generalObjectRepository;

        // Constructor to initialize the handler with the GeneralObject repository.
        public UpdateGeneralObjectCommandHandler(IGeneralObjectRepository generalObjectRepository)
        {
            _generalObjectRepository = generalObjectRepository;
        }

        // Handles the UpdateGeneralObjectCommand by adding or updating a GeneralObject in the repository.
        public async Task HandleAsync(UpdateGeneralObjectCommand command)
        {
            // Create a GeneralObject based on the command and add or update it in the repository.
            await _generalObjectRepository.AddOrUpdateAsync(UpdateGeneralObjectCommand.UpdateGeneralObject(command));
        }
    }
}
