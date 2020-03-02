using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Maps
{
    public class MappingProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("ID_PRODUCT");

            builder.Property(e => e.Name)
                   .HasColumnName("Nome_Produto")
                   .HasColumnType("varchar(40)")
                   .IsRequired();

            builder.Property(e => e.Price)
                   .HasColumnName("Nome_Produto")
                   .HasColumnType("varchar(40)")
                   .IsRequired();

            builder.HasOne(e => e.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.IdCategory)
                .IsRequired();
        }
    }
}
