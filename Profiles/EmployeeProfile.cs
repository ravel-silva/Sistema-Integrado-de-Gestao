using AutoMapper;
using Sistema_Integrado_de_Gestão.Data.Dtos;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateFuncionarioDto, Funcionario>();
            CreateMap<Funcionario, ReadFuncionarioDto>();
            CreateMap<UpdateFuncionarioDto, Funcionario>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                srcMember != null && !(srcMember is string str && string.IsNullOrWhiteSpace(str))));
        }
    }
}
