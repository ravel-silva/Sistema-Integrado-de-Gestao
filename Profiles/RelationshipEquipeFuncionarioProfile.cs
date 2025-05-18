using AutoMapper;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Profiles
{
    public class RelationshipEquipeFuncionarioProfile : Profile
    {
        public RelationshipEquipeFuncionarioProfile()
        {
            CreateMap<CreateRelationshipEquipeFuncionarioDto, EquipeFuncionario>()
                       .ForMember(dest => dest.equipeId, opt => opt.MapFrom(src => src.equipeId))
                       .ForMember(dest => dest.funcionarioId, opt => opt.MapFrom(src => src.funcionarioId))
                       .ForMember(dest => dest.dataEntrada, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<EquipeFuncionario, FuncionariosInfo>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.funcionario.Id))
                       .ForMember(dest => dest.NomeFuncionario, opt => opt.MapFrom(src => src.funcionario.Nome))
                       .ForMember(dest => dest.MatriculaFuncionario, opt => opt.MapFrom(src => src.funcionario.Matricula));

        }
    }
}
