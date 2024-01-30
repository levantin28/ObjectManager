using OM.Common.CQRS.Queries.Handler;
using OM.Services.ObjectManager.BLL.Queries.GeneralObjects;
using OM.Services.ObjectManager.Core.Models.Entities;
using OM.Services.ObjectManager.DAL.Repositories.GeneralObjects;
using OM.Services.ObjectManager.DAL.Repositories.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Services.ObjectManager.BLL.QueryHandlers.GeneralObjects
{
    public class GeneralObjectQueryHandlers : IQueryHandler<GetGeneralObjectQuery, GeneralObject>,
        IQueryHandler<GetGeneralObjectsQuery, List<GeneralObject>>,
        IQueryHandler<GetChildsGeneralObjectsQuery, List<GeneralObject>>,
        IQueryHandler<GetParentsGeneralObjectsQuery, List<GeneralObject>>,
        IQueryHandler<SearchGeneralObjectsQuery, List<GeneralObject>>,
        IQueryHandler<GetGeneralObjectByTypeQuery, List<GeneralObject>>
    {
        // Fields to store repositories for Relation and GeneralObject entities.
        private readonly IRelationRepository _relationRepository;
        private readonly IGeneralObjectRepository _generalObjectRepository;

        // Constructor to initialize query handlers with repositories.
        public GeneralObjectQueryHandlers(IRelationRepository relationRepository, IGeneralObjectRepository generalObjectRepository)
        {
            _relationRepository = relationRepository;
            _generalObjectRepository = generalObjectRepository;
        }

        // Handles the GetGeneralObjectQuery by retrieving a GeneralObject with the specified ID.
        public async Task<GeneralObject> HandleAsync(GetGeneralObjectQuery query)
        {
            return await _generalObjectRepository.GetAsync(query.Id);
        }

        // Handles the GetGeneralObjectsQuery by retrieving all GeneralObjects.
        public async Task<List<GeneralObject>> HandleAsync(GetGeneralObjectsQuery query)
        {
            return await _generalObjectRepository.GetAsync();
        }

        // Handles the GetChildsGeneralObjectsQuery by retrieving child GeneralObjects of a specified parent.
        public async Task<List<GeneralObject>> HandleAsync(GetChildsGeneralObjectsQuery query)
        {
            var relations = await _relationRepository.GetRelationsByParentObjectId(query.ParentObjectId);
            var generalObjects = new List<GeneralObject>();

            // Iterate through relations and retrieve corresponding child GeneralObjects.
            foreach (var relation in relations)
            {
                var generalObject = await _generalObjectRepository.GetAsync(relation.ChildObjectId);
                if (generalObject == null)
                    continue;

                generalObjects.Add(generalObject);
            }

            return generalObjects;
        }

        // Handles the GetParentsGeneralObjectsQuery by retrieving parent GeneralObjects of a specified child.
        public async Task<List<GeneralObject>> HandleAsync(GetParentsGeneralObjectsQuery query)
        {
            var relations = await _relationRepository.GetRelationsByChildObjectId(query.ChildObjectId);
            var generalObjects = new List<GeneralObject>();

            // Iterate through relations and retrieve corresponding parent GeneralObjects.
            foreach (var relation in relations)
            {
                var generalObject = await _generalObjectRepository.GetAsync(relation.ParentObjectId);
                if (generalObject == null)
                    continue;

                generalObjects.Add(generalObject);
            }

            return generalObjects;
        }

        // Handles the SearchGeneralObjectsQuery by searching for GeneralObjects based on a search string.
        public async Task<List<GeneralObject>> HandleAsync(SearchGeneralObjectsQuery query)
        {
            return await _generalObjectRepository.SearchGneralObjects(query.SearchString);
        }

        // Handles the GetGeneralObjectByTypeQuery by retrieving GeneralObjects of a specified type.
        public async Task<List<GeneralObject>> HandleAsync(GetGeneralObjectByTypeQuery query)
        {
            return await _generalObjectRepository.GetGeneralObjectsByType(query.Type);
        }
    }
}
