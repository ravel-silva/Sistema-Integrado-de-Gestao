using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Solicitacao_de_Material.Model;
using Solicitacao_de_Material.Model.Auth;

namespace Solicitacao_de_Material.Data
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<EquipeFuncionario> RelationshipEquipeFuncionario { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<RequisicaoDeMaterial> RequisicoesDeMaterial { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Renomear tabelas padrão do Identity
            builder.Entity<Usuario>().ToTable("Usuarios");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        }
    }
}
