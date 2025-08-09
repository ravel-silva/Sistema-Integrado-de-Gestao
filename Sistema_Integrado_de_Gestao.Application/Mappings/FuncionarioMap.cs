using AutoMapper;
using Sistema_Integrado_de_Gestao.Application.Dtos.Funcionario;
using Sistema_Integrado_de_Gestao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Application.Mappings
{
    public class FuncionarioMap : Profile
    {
        public FuncionarioMap()
        {
            CreateMap<Funcionario, FuncionarioCreateDTO>();
            CreateMap<FuncionarioCreateDTO, Funcionario>();
        }
    }
}
