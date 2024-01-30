using OM.Common.CQRS.Commands;
using OM.Services.ObjectManager.Core.Models.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Services.ObjectManager.BLL.Commands.Relations
{
    public class CreateRelationCommand : OMCommand
    {
        [Required]
        public int ParentObjectId { get; set; }
        [Required]
        public int ChildObjectId { get; set; }
        public static RelationApiModel CreateRelation(CreateRelationCommand model)
        {
            if (model == null) return null;
            return new RelationApiModel
            {
                ParentObjectId = model.ParentObjectId,
                ChildObjectId = model.ChildObjectId,
            };
        }
    }
}
