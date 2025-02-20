using Microsoft.AspNetCore.Authorization;

namespace Solicitacao_de_Material.Authorization
{
    public class AcessoAuthorization : AuthorizationHandler<NivelDeAcesso>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NivelDeAcesso requirement)
        {
            //verificar no banco de bados se o usuario tem o nivel de acesso (Equipe)
        }
    }
}
