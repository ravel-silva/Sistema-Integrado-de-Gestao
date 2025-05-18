using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Integrado_de_Gestão.Data.Dtos;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Services
{
    public class TeamService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public TeamService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //this method creates a new team
        public void CreateEquipe(CreateEquipeDto cadastroEquipeDto)
        {

            var novaEquipe = _mapper.Map<Equipe>(cadastroEquipeDto);
            _context.Equipes.Add(novaEquipe);
            _context.SaveChanges();

        }

        // This method views the list of teams
        public IEnumerable<ReadEquipeDto> GetEquipe(PaginationParameters parameters)
        {
            var equipes = _context.Equipes
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToList();
            var equipesDto = _mapper.Map<List<ReadEquipeDto>>(equipes);

            return equipesDto.ToList();
        }

        // This method views the team by ID
        public ReadEquipeDto? GetEquipeId(int id)
        {
            var equipes = _context.Equipes
                 .FirstOrDefault(e => e.Id == id); // Filtra pelo ID

            var equipesDto = _mapper.Map<ReadEquipeDto>(equipes); // Retorna como lista

            return equipesDto;

        }

        // this method deletes a team
        public bool DeleleteEquipe(int id)
        {
            var equipe = _context.Equipes.FirstOrDefault(e => e.Id == id);
            if (equipe == null)
            {
                return false;
            }
            _context.Equipes.Remove(equipe);
            _context.SaveChanges();
            return true;
        }


        //verificar se ja existe equipe cadastrada
        public bool VerificarEquipe(string prefixo)
        {
            return _context.Equipes.Any(equipe => equipe.Prefixo == prefixo);
        }

        public bool UpdateCadastroEquipe(int id, UpdateEquipeDto updateEquipeDto)
        {
            var team = _context.Equipes.FirstOrDefault(equipe => equipe.Id == id);
            if (team == null)
            {
                return false;
            }
            _mapper.Map(updateEquipeDto, team);
            _context.SaveChanges();
            return true;
        }
    }
}
