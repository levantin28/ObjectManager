using OM.Services.ObjectManager.Core.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Services.ObjectManager.Core.Models.Entities
{
    public class GeneralObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public static implicit operator GeneralObjectApiModel(GeneralObject model)
        {
            if (model == null) return null;
            return new GeneralObjectApiModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Type = model.Type,
            };
        }
    }
}
