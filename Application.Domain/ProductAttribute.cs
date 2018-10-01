using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain
{
    public class ProductAttribute: BaseEntity
    {
        public string Name { get; set; }        
        public Boolean IsActive { get; set; }  
        public ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }

    }
}
