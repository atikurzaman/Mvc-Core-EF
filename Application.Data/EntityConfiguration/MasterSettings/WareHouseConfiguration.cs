using Application.Domain.MasterSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration.MasterSettings
{
    public class WareHouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Name).HasMaxLength(256).IsRequired();
            builder.Property(b => b.Address).HasMaxLength(256).IsRequired();
            builder.Property(b => b.Mobile).HasMaxLength(256).IsRequired();
            builder.Property(b => b.Email).HasMaxLength(256).IsRequired();            
            builder.Property(b => b.IsActive).IsRequired();
            builder.ToTable("WareHouse");
        }
    }    
}
