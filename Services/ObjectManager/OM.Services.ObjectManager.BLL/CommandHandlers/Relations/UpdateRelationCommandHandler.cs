using OM.Common.CQRS.Commands.Handler;
using OM.Services.ObjectManager.BLL.Commands.Relations;
using OM.Services.ObjectManager.DAL.Repositories.Relations;

namespace OM.Services.ObjectManager.BLL.CommandHandlers.Relations
{
    public class UpdateRelationCommandHandler : ICommandHandler<UpdateRelationCommand>
    {
        // Field to store the repository responsible for handling Relation entities.
        private readonly IRelationRepository _relationRepository;

        // Constructor to initialize the handler with the Relation repository.
        public UpdateRelationCommandHandler(IRelationRepository relationRepository)
        {
            _relationRepository = relationRepository;
        }

        // Handles the UpdateRelationCommand by adding or updating a Relation in the repository.
        public async Task HandleAsync(UpdateRelationCommand command)
        {
            // Create a Relation based on the command and add or update it in the repository.
            await _relationRepository.AddOrUpdateAsync(UpdateRelationCommand.UpdateRelation(command));
        }
    }
}
