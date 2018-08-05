using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models
{
    public class RoleViewModel : BaseEntityViewModel
    {
        private string _normalizedName;        
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get => Name.ToUpper(); set => _normalizedName = Name; }
        public bool IsActive { get; set; }
        public SelectList IsActiveSelectList { get; set; }
    }
}
