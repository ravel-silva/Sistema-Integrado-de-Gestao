using AutoMapper;
using Sistema_Integrado_de_Gestao.Application.Dtos.Equipe;
using Sistema_Integrado_de_Gestao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Application.Mappings
{
    public class EquipeProfile : Profile
    {
        public EquipeProfile()
        {
            CreateMap<Equipe, EquipeCreateDTO>();
            CreateMap<EquipeCreateDTO, Equipe>();

            CreateMap<Equipe, EquipeReadDTO>();
            CreateMap<EquipeReadDTO, Equipe>();

            CreateMap<Equipe, EquipeUpdateDTO>();
            CreateMap<EquipeUpdateDTO, Equipe>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
