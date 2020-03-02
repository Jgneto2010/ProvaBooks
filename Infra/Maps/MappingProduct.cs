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


            builder.Property(e => e.NomeProduto)
                   .HasColumnName("Nome_Produto")
                   .HasColumnType("varchar(40)")
                   .IsRequired();

            builder.HasOne(e => e.usuario)
                .WithMany(e => e.ColecaoProdutos)
                .HasForeignKey(e => e.IdUsuario)
                .IsRequired();
        }
    }
}
