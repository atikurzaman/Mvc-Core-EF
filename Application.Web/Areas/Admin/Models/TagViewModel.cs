using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models
{
    public class TagViewModel : BaseEntityViewModel
    {
        [Required, MaxLength(256)]
        public string Name { get; set; }

        [DisplayName("Active"), Required()]
        public bool IsActive { get; set; }
    }
}
