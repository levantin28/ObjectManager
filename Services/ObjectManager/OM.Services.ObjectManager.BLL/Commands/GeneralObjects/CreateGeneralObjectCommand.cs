using OM.Common.CQRS.Commands;
using OM.Services.ObjectManager.Core.Models.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Services.ObjectManager.BLL.Commands.GeneralObjects
{
    public class CreateGeneralObjectCommand : OMCommand
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        public static GeneralObjectApiModel CreateGeneralObject(CreateGeneralObjectCommand model)
        {
            if (model == null) return null;
            return new GeneralObjectApiModel
            {
                Name = model.Name,
                Description = model.Description,
                Type = model.Type,
            };
        }
    }
}
