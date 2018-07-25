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

        [Required, DisplayName("Name")]
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public Boolean IsActive { get; set; }

        [DisplayName("Parent Category")]
        public Int64? ParentId { get; set; } = null;
        public CategoryViewModel ChildCategory { get; set; }
        public SelectList CategorySelectList { get; set; }

        [DisplayName("Parent Category Name")]
        public string ParentCategoryName { get; set; }
        public List<CategoryViewModel> Children { get; set; }
    }
}
