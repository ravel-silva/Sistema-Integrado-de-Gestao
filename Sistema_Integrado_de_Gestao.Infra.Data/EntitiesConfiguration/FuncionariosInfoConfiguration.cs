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
    public class FuncionariosInfoConfiguration : IEntityTypeConfiguration<FuncionariosInfo>
    {
        public void Configure(EntityTypeBuilder<FuncionariosInfo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeFuncionario)
                .HasMaxLength(100)
                .IsRequired();
          
            builder.Property(x => x.MatriculaFuncionario)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
