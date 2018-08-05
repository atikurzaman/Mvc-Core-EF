using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration
{
    public class AttributeValueConfiguration : IEntityTypeConfiguration<AttributeValue>
    {
        public void Configure(EntityTypeBuilder<AttributeValue> builder)
        {
            builder.Property(av => av.Id).ValueGeneratedOnAdd();
            builder.Property(av => av.Name).HasMaxLength(256).IsRequired();
            builder.Property(av => av.IsActive).IsRequired();
            builder.ToTable("AttributeValue");

            //builder.HasOne(a => a.Attribute)
            //.WithMany(av => av.AttributeValues)
            //.HasForeignKey(a => a.AttributeId);
        }
    }
}
