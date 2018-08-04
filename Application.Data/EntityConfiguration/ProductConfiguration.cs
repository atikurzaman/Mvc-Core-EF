using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Name).HasMaxLength(256).IsRequired();
            builder.Property(m => m.Slug).HasMaxLength(256).IsRequired();
            builder.Property(m => m.ShortDescription).HasMaxLength(256).IsRequired();
            builder.Property(m => m.Description).HasMaxLength(1024);
            builder.Property(m => m.IsActive);
            builder.HasKey(m => m.Id);
            builder.ToTable("Product");           
        }
    }
}
