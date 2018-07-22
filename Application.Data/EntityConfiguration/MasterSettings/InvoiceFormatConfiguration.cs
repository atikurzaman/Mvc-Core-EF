using Application.Domain.MasterSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration.MasterSettings
{
    public class InvoiceFormatConfiguration : IEntityTypeConfiguration<InvoiceFormat>
    {
        public void Configure(EntityTypeBuilder<InvoiceFormat> builder)
        {
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.CompanyName).HasMaxLength(256).IsRequired();
            builder.Property(b => b.Logo).HasMaxLength(256).IsRequired();
            builder.Property(b => b.Address).HasMaxLength(256).IsRequired();
            builder.Property(b => b.Other).HasMaxLength(256).IsRequired();
            builder.Property(b => b.Footer).HasMaxLength(256).IsRequired();
            builder.Property(b => b.IsActive).IsRequired();
            builder.ToTable("InvoiceFormat");
        }        
    }
}
