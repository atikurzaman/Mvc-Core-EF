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
    public class MenuViewModel
    {  
        public Int64 Id { get; set; }

        [Required, DisplayName("Name")]
        public string Name { get; set; }

        [Required, DisplayName("Controller Name")]
        public string ControllerName { get; set; }

        [Required,DisplayName("Action Name")]
        public string ActionName { get; set; }
        public string CssClass { get; set; }
        public Boolean IsActive { get; set; }

        [DisplayName("Parent Menu")]
        public Int64? ParentId { get; set; } = null;
        public virtual MenuViewModel ChildMenu { get; set; }
        public SelectList MenuSelectList { get; set; }

        [DisplayName("Parent Menu Name")]
        public string ParentMenuName { get; set; }        
        public List<MenuViewModel> Children { get; set; }
    }
}
