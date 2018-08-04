using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public Boolean IsActive { get; set; }

        [ForeignKey(nameof(ProductCategory))]
        public Int64? ProductCategoryId { get; set; }
        public Category ProductCategory { get; set; }

        [ForeignKey(nameof(Brand))]
        public Int64? BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }        
    }
}
