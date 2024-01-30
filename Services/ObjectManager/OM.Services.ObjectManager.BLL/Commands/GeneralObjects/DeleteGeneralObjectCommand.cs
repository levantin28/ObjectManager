﻿using OM.Common.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Services.ObjectManager.BLL.Commands.GeneralObjects
{
    public class DeleteGeneralObjectCommand : OMCommand
    {
        [Required]
        public int Id { get; set; }
    }
}
