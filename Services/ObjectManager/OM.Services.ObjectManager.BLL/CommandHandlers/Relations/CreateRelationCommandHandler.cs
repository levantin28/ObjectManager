using OM.Common.CQRS.Commands.Handler;
using OM.Services.ObjectManager.BLL.Commands.Relations;
using OM.Services.ObjectManager.DAL.Repositories.Relations;

namespace OM.Services.ObjectManager.BLL.CommandHandlers.Relations
{
    public class CreateRelationCommandHandler : ICommandHandler<CreateRelationCommand>
    {
        // Field to store the repository responsible for handling Relation entities.
        private readonly IRelationRepository _relationRepository;

        // Constructor to initialize the handler with the Relation repository.
        public CreateRelationCommandHandler(IRelationRepository relationRepository)
        {
            _relationRepository = relationRepository;
        }

        // Handles the CreateRelationCommand by adding or updating a Relation in the repository.
        public async Task HandleAsync(CreateRelationCommand command)
        {
            // Create a Relation based on the command and add or update it in the repository.
            await _relationRepository.AddOrUpdateAsync(CreateRelationCommand.CreateRelation(command));
        }
    }
}
