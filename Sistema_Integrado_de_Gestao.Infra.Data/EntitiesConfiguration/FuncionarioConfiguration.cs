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
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Matricula)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(x => x.DataCriacao)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }
    }
}
