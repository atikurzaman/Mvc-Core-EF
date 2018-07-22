using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.EntityConfiguration
{
    public class AttributeConfiguration : IEntityTypeConfiguration<Attribute>
    {       
        public void Configure(EntityTypeBuilder<Attribute> builder)
        {            
            builder.Property(c=>c.Id).ValueGeneratedOnAdd();
            builder.Property(c =>c.Name).HasMaxLength(128).IsRequired();            
            builder.Property(c => c.IsActive).IsRequired();
            builder.ToTable("Attribute");            
        }
    }
}
