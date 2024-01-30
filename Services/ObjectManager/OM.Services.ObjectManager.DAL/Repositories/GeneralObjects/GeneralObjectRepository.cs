using CCP.FTR.Common.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using OM.Services.ObjectManager.Core.Models.Entities;
using OM.Services.ObjectManager.DAL.Context;

namespace OM.Services.ObjectManager.DAL.Repositories.GeneralObjects
{
    public class GeneralObjectRepository : GenericRepository<GeneralObject, OMDbContext>, IGeneralObjectRepository
    {
        // Constructor to initialize the repository with the database context.
        public GeneralObjectRepository(OMDbContext context) : base(context)
        {
            // The base constructor is called with the provided database context.
        }

        // Retrieves a GeneralObject by its name.
        public async Task<GeneralObject> GetGeneralObjectByName(string name)
        {
            // Use the GetQuery method to retrieve a GeneralObject by name from the database.
            return await this.GetQuery().FirstOrDefaultAsync(d => d.Name == name);
        }

        // Searches for GeneralObjects based on a search string in the name or description.
        public async Task<List<GeneralObject>> SearchGneralObjects(string searchString)
        {
            // Use the GetQuery method to filter GeneralObjects containing the search string in name or description.
            return await this.GetQuery().Where(x => x.Name.Contains(searchString) || x.Description.Contains(searchString)).ToListAsync();
        }

        // Retrieves GeneralObjects by their type.
        public async Task<List<GeneralObject>> GetGeneralObjectsByType(string type)
        {
            // Use the GetQuery method to filter GeneralObjects by type.
            return await this.GetQuery().Where(x => x.Type == type).ToListAsync();
        }
    }
}
