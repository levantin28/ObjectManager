using OM.Common.CQRS.Queries.Handler;
using OM.Services.ObjectManager.BLL.Queries.GeneralObjects;
using OM.Services.ObjectManager.BLL.Queries.Relations;
using OM.Services.ObjectManager.Core.Models.Entities;
using OM.Services.ObjectManager.DAL.Repositories.GeneralObjects;
using OM.Services.ObjectManager.DAL.Repositories.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Services.ObjectManager.BLL.QueryHandlers.Relations
{
    public class RelationQueryHandlers : IQueryHandler<GetRelationQuery, Relation>,
        IQueryHandler<GetRelationsQuery, List<Relation>>
    {
        // Fields to store repositories for Relation and GeneralObject entities.
        private readonly IRelationRepository _relationRepository;
        private readonly IGeneralObjectRepository _generalObjectRepository;

        // Constructor to initialize query handlers with repositories.
        public RelationQueryHandlers(IRelationRepository relationRepository, IGeneralObjectRepository generalObjectRepository)
        {
            _relationRepository = relationRepository;
            _generalObjectRepository = generalObjectRepository;
        }

        // Handles the GetRelationQuery by retrieving a Relation with the specified ID.
        public async Task<Relation> HandleAsync(GetRelationQuery query)
        {
            return await _relationRepository.GetAsync(query.Id);
        }

        // Handles the GetRelationsQuery by retrieving all Relations.
        public async Task<List<Relation>> HandleAsync(GetRelationsQuery query)
        {
            return await _relationRepository.GetAsync();
        }
    }
}
