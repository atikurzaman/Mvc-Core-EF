using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models.MasterSettings
{
    public class InvoiceFormatViewModel:BaseEntityViewModel
    {
        public string CompanyName { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string Other { get; set; }
        public string Footer { get; set; }        
        public Int64? WarehouseId { get; set; }        
        public Boolean IsActive { get; set; }
    }
}
