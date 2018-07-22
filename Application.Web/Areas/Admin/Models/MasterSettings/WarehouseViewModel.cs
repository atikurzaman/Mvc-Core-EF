using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models.MasterSettings
{
    public class WarehouseViewModel:BaseEntityViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Boolean IsActive { get; set; }
    }
}
