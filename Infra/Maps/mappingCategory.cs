using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Maps
{
    public class MappingCategory : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("ID_CATEGORY");

            builder.Property(e => e.Name)
                .HasColumnName("Name_CATEGORY")
                .HasColumnType("varchar(40)")
                .IsRequired();

            builder.HasMany(e => e.Products)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.IdCategory)
                .IsRequired();
        }
    }
}
