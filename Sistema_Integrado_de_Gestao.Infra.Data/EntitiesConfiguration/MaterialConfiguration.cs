using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Integrado_de_Gestao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Infra.Data.EntitiesConfiguration
{
    internal class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Codigo)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(x => x.Codigo)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Descricao)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Unidade)
                .HasMaxLength(3)
                .IsRequired();
            builder.Property(x => x.Status)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(x => x.DataCriacao)
          .HasDefaultValue(DateTime.Now)
          .IsRequired();

        }
    }
}
