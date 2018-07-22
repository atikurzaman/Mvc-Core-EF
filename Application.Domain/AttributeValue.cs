using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain
{
    public class AttributeValue : BaseEntity
    {
        public string Name { get; set; }        

        public Boolean IsActive { get; set; }

        [ForeignKey(nameof(Attribute))]
        public Int64 AttributeId { get; set; }

        public Attribute Attribute { get; set; }
    }
}
