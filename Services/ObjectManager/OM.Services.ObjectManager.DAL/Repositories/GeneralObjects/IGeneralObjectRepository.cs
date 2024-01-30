using OM.Common.Infrastructure.Repositories.Generic;
using OM.Services.ObjectManager.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Services.ObjectManager.DAL.Repositories.GeneralObjects
{
    public interface IGeneralObjectRepository : IGenericRepository<GeneralObject>
    {
        Task<GeneralObject> GetGeneralObjectByName(string name);
        Task<List<GeneralObject>> SearchGneralObjects(string searchString);
        Task<List<GeneralObject>> GetGeneralObjectsByType(string type);
    }
}
