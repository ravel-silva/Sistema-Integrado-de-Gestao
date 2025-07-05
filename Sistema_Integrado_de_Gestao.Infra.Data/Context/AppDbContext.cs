using Microsoft.EntityFrameworkCore;
using Sistema_Integrado_de_Gestao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opts) : base(opts) { }
        public DbSet<Equipe> Equipe { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<EquipeFuncionario> RelationshipEquipeFuncionario { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<RequisicaoDeMaterial> RequisicoesDeMaterial { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}



