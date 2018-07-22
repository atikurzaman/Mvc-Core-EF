using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.MasterSettings
{
    public class Warehouse: BaseEntity
    {        
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Boolean IsActive { get; set; }
    }
}
