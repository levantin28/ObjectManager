using CCP.FTR.Common.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using OM.Services.ObjectManager.Core.Models.Entities;
using OM.Services.ObjectManager.DAL.Context;

namespace OM.Services.ObjectManager.DAL.Repositories.Relations
{
    public class RelationRepository : GenericRepository<Relation, OMDbContext>, IRelationRepository
    {
        // Constructor to initialize the repository with the database context.
        public RelationRepository(OMDbContext context) : base(context)
        {
            // The base constructor is called with the provided database context.
        }

        // Retrieves a list of relations where the specified object is the parent.
        public async Task<List<Relation>> GetRelationsByParentObjectId(int parentObjectId)
        {
            // Use the GetQuery method to filter relations by parent object ID.
            return await this.GetQuery().Where(d => d.ParentObjectId == parentObjectId).ToListAsync();
        }

        // Retrieves a list of relations where the specified object is the child.
        public async Task<List<Relation>> GetRelationsByChildObjectId(int childObjectId)
        {
            // Use the GetQuery method to filter relations by child object ID.
            return await this.GetQuery().Where(d => d.ChildObjectId == childObjectId).ToListAsync();
        }

        // Checks if a relation exists between the specified parent and child objects.
        public async Task<bool> RelationExists(int parentObjectId, int childObjectId)
        {
            // Use the GetQuery method to find a relation with the specified parent and child object IDs.
            var relation = await this.GetQuery().FirstOrDefaultAsync(x => x.ParentObjectId == parentObjectId && x.ChildObjectId == childObjectId);

            // Return true if a relation is found, otherwise false.
            return relation != null;
        }

        // Checks if a vice versa relation exists between the specified parent and child objects.
        public async Task<bool> ViceversaRelationExists(int parentObjectId, int childObjectId)
        {
            // Use the GetQuery method to find a relation with the specified child and parent object IDs.
            var relation = await this.GetQuery().FirstOrDefaultAsync(x => x.ParentObjectId == childObjectId && x.ChildObjectId == parentObjectId);

            // Return true if a relation is found, otherwise false.
            return relation != null;
        }
    }
}
