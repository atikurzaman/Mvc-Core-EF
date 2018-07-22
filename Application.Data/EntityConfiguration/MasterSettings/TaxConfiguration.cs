using Application.Domain.MasterSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration.MasterSettings
{
    public class TaxConfiguration:IEntityTypeConfiguration<Tax>
    {
        public void Configure(EntityTypeBuilder<Tax> builder)
        {
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Name).HasMaxLength(256).IsRequired();
            builder.Property(b => b.TaxRate).IsRequired();
            builder.Property(b => b.Other).HasMaxLength(256).IsRequired(false);
            builder.Property(b => b.IsActive).HasMaxLength(256).IsRequired();
            builder.ToTable("Tax");
        }        
    }
}
