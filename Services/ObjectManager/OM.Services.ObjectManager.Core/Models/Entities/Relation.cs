using OM.Services.ObjectManager.Core.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OM.Services.ObjectManager.Core.Models.Entities
{
    public class Relation
    {
        public Guid Id { get; set; }
        public int ParentObjectId { get; set; }
        public int ChildObjectId { get; set; }

        public static implicit operator RelationApiModel(Relation model)
        {
            if (model == null) return null;
            return new RelationApiModel
            {
                Id = model.Id,
                ParentObjectId = model.ParentObjectId,
                ChildObjectId = model.ChildObjectId,
            };
        }
    }
}
