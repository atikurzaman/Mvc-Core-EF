using Application.Domain.MasterSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration.MasterSettings
{
    public class StockInventoryTypeConfiguration : IEntityTypeConfiguration<StockInventoryType>
    {
        public void Configure(EntityTypeBuilder<StockInventoryType> builder)
        {
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Name).HasMaxLength(256).IsRequired();            
            builder.Property(b => b.IsActive).IsRequired();
            builder.ToTable("StockInventoryType");
        }        
    }
}
