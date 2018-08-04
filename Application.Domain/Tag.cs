using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain
{
    public class Tag:BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
