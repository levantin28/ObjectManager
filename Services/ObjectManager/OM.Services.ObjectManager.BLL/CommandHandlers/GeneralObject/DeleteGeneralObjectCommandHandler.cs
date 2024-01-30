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
    public class DeleteGeneralObjectCommandHandler : ICommandHandler<DeleteGeneralObjectCommand>
    {
        // Field to store the repository responsible for handling GeneralObject entities.
        private readonly IGeneralObjectRepository _generalObjectRepository;

        // Constructor to initialize the handler with the GeneralObject repository.
        public DeleteGeneralObjectCommandHandler(IGeneralObjectRepository generalObjectRepository)
        {
            _generalObjectRepository = generalObjectRepository;
        }

        // Handles the DeleteGeneralObjectCommand by deleting a GeneralObject from the repository.
        public async Task HandleAsync(DeleteGeneralObjectCommand command)
        {
            // Delete the GeneralObject with the specified ID from the repository.
            await _generalObjectRepository.DeleteAsync(command.Id);
        }
    }
}
