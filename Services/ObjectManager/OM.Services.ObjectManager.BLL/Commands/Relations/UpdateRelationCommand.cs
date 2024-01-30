using OM.Common.CQRS.Commands;
using OM.Services.ObjectManager.BLL.Commands.GeneralObjects;
using OM.Services.ObjectManager.Core.Models.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Services.ObjectManager.BLL.Commands.Relations
{
    public class UpdateRelationCommand : OMCommand
    {
        [Required]
        public Guid Id { get; set; }
        public int ParentObjectId { get; set; }
        public int ChildObjectId { get; set; }

        public static RelationApiModel UpdateRelation(UpdateRelationCommand model)
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
