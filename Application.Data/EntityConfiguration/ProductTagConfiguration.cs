using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.EntityConfiguration
{
    public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            builder.HasKey(pt => new { pt.ProductId, pt.TagId });

            builder.HasOne(pt => pt.Product)
            .WithMany(p => p.ProductTags)
            .HasForeignKey(pt => pt.ProductId);

            builder.HasOne(pt => pt.Tag)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.TagId);
        }
    }
}
