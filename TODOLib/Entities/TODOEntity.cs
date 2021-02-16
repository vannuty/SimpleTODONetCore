using System;
using System.Collections.Generic;
using System.Text;
using TODOLib.Entities.Base;

namespace TODOLib.Entities
{
    public class TODOEntity : BaseEntity
    {
        public string Description { get; set; }
        public string Notes { get; set; }

        public void Update(TODOEntity tODOEntity)
        {
            Description = tODOEntity.Description;
            Notes = tODOEntity.Notes;
        }
    }
}
