using OM.Common.Infrastructure.Repositories.Generic;
using OM.Services.ObjectManager.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Services.ObjectManager.DAL.Repositories.Relations
{
    public interface IRelationRepository : IGenericRepository<Relation>
    {
        Task<List<Relation>> GetRelationsByParentObjectId(int parentObjectId);
        Task<List<Relation>> GetRelationsByChildObjectId(int childObjectId);
        Task<bool> RelationExists(int parentObjectId, int childObjectId);
        Task<bool> ViceversaRelationExists(int parentObjectId, int childObjectId);
    }
}
