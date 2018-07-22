using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models.MasterSettings
{
    public class SettingViewModel:BaseEntityViewModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Group { get; set; }        
        public Int64? WarehouseId { get; set; }        
        public Boolean IsActive { get; set; }
    }
}
