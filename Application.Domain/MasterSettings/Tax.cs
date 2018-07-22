using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.MasterSettings
{
    public class Tax:BaseEntity
    {
        public string Name { get; set; }
        public Double TaxRate { get; set; }
        public string Other { get; set; }        
        public Boolean IsActive { get; set; }
    }
}
