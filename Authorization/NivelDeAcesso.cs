using Microsoft.AspNetCore.Authorization;

namespace Solicitacao_de_Material.Authorization
{
    public class NivelDeAcesso : IAuthorizationRequirement
    {
        public NivelDeAcesso(string nivelAcesso)
        {
            NivelAcesso = nivelAcesso;
        }
        public string NivelAcesso { get; set; }
    }
}
