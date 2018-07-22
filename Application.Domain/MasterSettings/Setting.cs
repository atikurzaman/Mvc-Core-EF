using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain.MasterSettings
{
    public class Setting:BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Group { get; set; }

        [ForeignKey(nameof(Warehouse))]
        public Int64? WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public Boolean IsActive { get; set; }
    }
}
