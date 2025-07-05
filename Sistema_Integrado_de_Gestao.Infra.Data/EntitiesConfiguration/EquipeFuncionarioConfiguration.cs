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
    public class EquipeFuncionarioConfiguration : IEntityTypeConfiguration<EquipeFuncionario>
    {
        public void Configure(EntityTypeBuilder<EquipeFuncionario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EquipeId)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(x => x.FuncionarioId)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(x => x.dataEntrada)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.HasOne(x => x.equipe).WithMany(x => x.EquipesFuncionarios).HasForeignKey(x => x.EquipeId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.funcionario).WithMany(x => x.EquipesFuncionarios).HasForeignKey(x => x.FuncionarioId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
