using Microsoft.AspNetCore.Authorization;
using Solicitacao_de_Material.Data;
using System.Security.Claims;

namespace Solicitacao_de_Material.Authorization
{
    public class AcessoAuthorization : AuthorizationHandler<NivelDeAcesso> // basico e adm
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NivelDeAcesso requirement)
        {

            var nivelDeAcessoClaim = context.
                User.FindFirst(claim => claim.Type == ClaimTypes.Role);

            if (nivelDeAcessoClaim is null)
            {
                return Task.CompletedTask;
            }
            if (nivelDeAcessoClaim.Value == "Administrador")
            {
                context.Succeed(requirement);
            }
            else if (nivelDeAcessoClaim.Value == "Basico")
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
