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
    public class RequisicaoDeMaterialConfiguration : IEntityTypeConfiguration<RequisicaoDeMaterial>
    {
        public void Configure(EntityTypeBuilder<RequisicaoDeMaterial> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EquipeId)
                .IsRequired();
            builder.Property(x => x.Status)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(x => x.DataDaRequisicao)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }


    }
}

