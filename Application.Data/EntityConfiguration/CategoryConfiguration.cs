using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.EntityConfiguration
{
    public class CategoryConfiguration: IEntityTypeConfiguration<Category>
    {       
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Name).HasMaxLength(256).IsRequired();
            builder.Property(m => m.Slug).HasMaxLength(256).IsRequired(false);
            builder.Property(m => m.Description).HasMaxLength(256).IsRequired(false);
            builder.Property(m => m.IsActive);
            builder.Property(m => m.ParentId);
            builder.HasKey(m => m.Id);
            builder.ToTable("Category");            
        }
    }
}
