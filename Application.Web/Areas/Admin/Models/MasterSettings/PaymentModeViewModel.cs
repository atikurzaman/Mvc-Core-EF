using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models.MasterSettings
{
    public class PaymentModeViewModel:BaseEntityViewModel
    {
        public string Name { get; set; }
        public Boolean IsActive { get; set; }
    }
}
