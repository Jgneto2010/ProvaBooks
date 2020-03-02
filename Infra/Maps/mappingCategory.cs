using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Maps
{
    public class MappingCategory : IEntityConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("ID_PROD");


            builder.Property(e => e.Name)
                .HasColumnName("Nome_Produto")
                .HasColumnType("varchar(40)")
                .IsRequired();

            builder.HasOne(e => e.product)
                .WithMany(e => e.ColecaoProdutos)
                .HasForeignKey(e => e.IdUsuario)
                .IsRequired();
        }
    }
}
