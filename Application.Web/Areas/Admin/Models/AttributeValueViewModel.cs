using Application.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models
{
    public class AttributeValueViewModel:BaseEntityViewModel
    {        

        [Required,MaxLength(256)]
        public string Name { get; set; }        

        [Required,DisplayName("Active")]
        public Boolean IsActive { get; set; }

        [Required]
        public Int64 AttributeId { get; set; }
        
    }
}
