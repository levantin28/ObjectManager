using OM.Common.CQRS.Queries;
using OM.Services.ObjectManager.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Services.ObjectManager.BLL.Queries.GeneralObjects
{
    public class GetParentsGeneralObjectsQuery : OMQuery<List<GeneralObject>>
    {
        public int ChildObjectId { get; set; }
        public GetParentsGeneralObjectsQuery(int childObjectId)
        {
            ChildObjectId = childObjectId;
        }
    }
}
