using OM.Common.CQRS.Commands.Handler;
using OM.Services.ObjectManager.BLL.Commands.Relations;
using OM.Services.ObjectManager.DAL.Repositories.Relations;

namespace OM.Services.ObjectManager.BLL.CommandHandlers.Relations
{
    public class DeleteRelationCommandHandler : ICommandHandler<DeleteRelationCommand>
    {
        // Field to store the repository responsible for handling Relation entities.
        private readonly IRelationRepository _relationRepository;

        // Constructor to initialize the handler with the Relation repository.
        public DeleteRelationCommandHandler(IRelationRepository relationRepository)
        {
            _relationRepository = relationRepository;
        }

        // Handles the DeleteRelationCommand by deleting a Relation from the repository.
        public async Task HandleAsync(DeleteRelationCommand command)
        {
            // Delete the Relation with the specified ID from the repository.
            await _relationRepository.DeleteAsync(command.Id);
        }
    }
}
