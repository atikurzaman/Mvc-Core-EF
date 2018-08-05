using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models
{
    public class BrandViewModel : BaseEntityViewModel
    {
        [Required, MaxLength(256)]
        public string Name { get; set; }

        [Required, DisplayName("Active")]
        public bool IsActive { get; set; }
        public SelectList IsActiveSelectList { get; set; }
    }
}
