using AutoMapper;
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
        }
    }
}
