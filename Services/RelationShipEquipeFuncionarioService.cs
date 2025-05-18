using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Services
{
    public class RelationShipEquipeFuncionarioService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public RelationShipEquipeFuncionarioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // check if the relationship already exists
        public bool CheckRelationship(int equipeId, int funcionarioId)
        {
            var relacao = _context.RelationshipEquipeFuncionario.FirstOrDefault(relacao => relacao.equipeId == equipeId && relacao.funcionarioId == funcionarioId);
            if (relacao == null)
            {
                return false;
            }
            return true;
        }

        // create if team and employee exist
        public bool CheckTeamEmployee(CreateRelationshipEquipeFuncionarioDto relationshipEquipeFuncionarioDto)
        {
            var equipe = _context.Equipes.FirstOrDefault(equipe => equipe.Id == relationshipEquipeFuncionarioDto.equipeId);
            var funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.Id == relationshipEquipeFuncionarioDto.funcionarioId);
            if (equipe == null || funcionario == null)
            {
                return false;
            }
            return true;
        }

        // create the relationship
        public void CreateRelationship(CreateRelationshipEquipeFuncionarioDto relationshipEquipeFuncionarioDto)
        {

            var relacao = _mapper.Map<EquipeFuncionario>(relationshipEquipeFuncionarioDto);
            _context.RelationshipEquipeFuncionario.Add(relacao);
            _context.SaveChanges();
        }

        // get all relationships
        public IEnumerable<ReadRelationshipEquipeFuncionarioDto> GetRelationship(PaginationParameters parameters)
        {
            var dados = _context.RelationshipEquipeFuncionario
                .Include(relacao => relacao.equipe)
                .Include(relacao => relacao.funcionario)
                .ToList();


            var grupos = dados
                .GroupBy(r => new { r.equipeId, r.equipe.Prefixo })
                .Select(grupo => new ReadRelationshipEquipeFuncionarioDto
                {
                    Id = grupo.First().Id,
                    equipeId = grupo.Key.equipeId,
                    equipePrefixo = grupo.Key.Prefixo,
                    funcionarios = grupo
                        .Select(relacao => _mapper.Map<FuncionariosInfo>(relacao))
                        .ToList(),
                    dataEntrada = grupo.First().dataEntrada
                }).Skip((parameters.PageNumber - 1) * parameters.PageSize)
                  .Take(parameters.PageSize);
            return grupos.ToList();
        }
        public IEnumerable<ReadRelationshipEquipeFuncionarioDto> GetRelationshipById(int id)
        {
            var dados = _context.RelationshipEquipeFuncionario
                .Include(relacao => relacao.equipe)
                .Include(relacao => relacao.funcionario)
                .Where(relacao => relacao.equipeId == id)
                .ToList();

            var gupos = dados
                .GroupBy(relacao => new { relacao.equipeId, relacao.equipe.Prefixo })
                .Select(grupo => new ReadRelationshipEquipeFuncionarioDto
                {
                    Id = grupo.First().Id,
                    equipeId = grupo.Key.equipeId,
                    equipePrefixo = grupo.Key.Prefixo,
                    funcionarios = grupo
                    .Select(relacao => _mapper.Map<FuncionariosInfo>(relacao))
                .ToList(),
                    dataEntrada = grupo.First().dataEntrada
                });
            return gupos.ToList();
        }
        public bool DeleteRelationship(int id)
        {
            var relacao = _context.RelationshipEquipeFuncionario.FirstOrDefault(relacao => relacao.equipeId == id);
            if (relacao == null)
            {
                return false;
            }
            _context.RelationshipEquipeFuncionario.Remove(relacao);
            _context.SaveChanges();
            return true;
        }
    }
}
