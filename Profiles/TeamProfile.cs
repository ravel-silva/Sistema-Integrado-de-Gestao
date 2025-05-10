using AutoMapper;
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
        }
    }
}
