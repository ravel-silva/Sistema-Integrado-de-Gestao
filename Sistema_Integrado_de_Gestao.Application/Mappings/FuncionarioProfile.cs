using AutoMapper;
using Sistema_Integrado_de_Gestao.Application.Dtos.Equipe;
using Sistema_Integrado_de_Gestao.Application.Dtos.Funcionario;
using Sistema_Integrado_de_Gestao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Application.Mappings
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<Funcionario, FuncionarioCreateDTO>();
            CreateMap<FuncionarioCreateDTO, Funcionario>();

            CreateMap<Funcionario, FuncionarioReadDTO>();
            CreateMap<FuncionarioReadDTO, Funcionario>();

            CreateMap<Funcionario, FuncionarioUpdateDTO>();
            CreateMap<FuncionarioUpdateDTO, Funcionario>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); ;

        }
    }
}
