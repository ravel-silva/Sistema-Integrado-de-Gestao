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
    public class ListMaterialConfiguration : IEntityTypeConfiguration<ListMaterial>
    {
        public void Configure(EntityTypeBuilder<ListMaterial> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RequisicaoDeMaterialId)
                .IsRequired();
            builder.Property(x => x.MaterialId)
                .IsRequired();
            builder.Property(x => x.Quantidade)
                .IsRequired();
        }
    }
}
