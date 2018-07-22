using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.MasterSettings
{
    public class StockInventoryType : BaseEntity
    {
        public string Name { get; set; }        
        public Boolean IsActive { get; set; }
    }
}
