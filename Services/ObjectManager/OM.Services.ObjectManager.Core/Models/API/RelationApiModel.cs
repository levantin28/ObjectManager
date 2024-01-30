using OM.Services.ObjectManager.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OM.Services.ObjectManager.Core.Models.API
{
    public class RelationApiModel
    {
        public Guid Id { get; set; }
        public int ParentObjectId { get; set; }
        public int ChildObjectId { get; set; }

        public static implicit operator Relation(RelationApiModel model)
        {
            if (model == null) return null;
            return new Relation
            {
                Id = model.Id,
                ParentObjectId = model.ParentObjectId,
                ChildObjectId = model.ChildObjectId,
            };
        }
    }
}
