using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain
{
    public class ProductAttributeValue : BaseEntity
    {
        public string Name { get; set; }        

        public Boolean IsActive { get; set; }

        [ForeignKey(nameof(ProductAttribute))]
        public Int64 ProductAttributeId { get; set; }

        public ProductAttribute ProductAttribute { get; set; }
    }
}
