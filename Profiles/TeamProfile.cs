using AutoMapper;
using Sistema_Integrado_de_Gestão.Data.Dtos;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<CreateEquipeDto, Equipe>();
            CreateMap<Equipe, ReadEquipeDto>();
            CreateMap<UpdateEquipeDto, Equipe>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
            srcMember != null && !(srcMember is string str && string.IsNullOrWhiteSpace(str))));
        }
    }
}
