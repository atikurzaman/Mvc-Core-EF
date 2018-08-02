using Application.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models
{
    public class CategoryViewModel:BaseEntityViewModel
    {        

        [Required, DisplayName("Name"),MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Slug { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        [Required, DisplayName("Active")]
        public Boolean IsActive { get; set; } = true;

        [DisplayName("Parent Category")]
        public Int64? ParentId { get; set; } = null;
        public CategoryViewModel ChildCategory { get; set; }      

        [DisplayName("Parent Category Name")]
        public string ParentCategoryName { get; set; }
        public List<CategoryViewModel> Children { get; set; }
        public SelectList CategorySelectList { get; set; }
        public SelectList IsActiveSelectList { get; set; }
    }
}
