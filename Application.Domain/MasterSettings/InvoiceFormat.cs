using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain.MasterSettings
{
    public class InvoiceFormat:BaseEntity
    {
        public string CompanyName { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }        
        public string Other { get; set; }
        public string Footer { get; set; }

        [ForeignKey(nameof(Warehouse))]
        public Int64? WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public Boolean IsActive { get; set; }
    }
}
