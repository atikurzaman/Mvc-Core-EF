using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Domain
{
    public class Category:BaseEntity
    {        
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public Boolean IsActive { get; set; }

        [ForeignKey(nameof(ParentCategory))]
        public Int64? ParentId { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> Children { get; set; }

        [NotMapped]
        public string ParentCategoryName { get; set; }
    }
}
