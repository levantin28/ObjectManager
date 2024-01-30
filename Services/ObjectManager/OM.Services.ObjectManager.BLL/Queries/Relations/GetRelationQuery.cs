﻿using OM.Common.CQRS.Queries;
using OM.Services.ObjectManager.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Services.ObjectManager.BLL.Queries.Relations
{
    public class GetRelationQuery : OMQuery<Relation>
    {
        public Guid Id { get; set; }
        public GetRelationQuery(Guid id)
        {
            Id = id;
        }
    }
}
