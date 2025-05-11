using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Services
{
    public class EmployeeService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public EmployeeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateCadastroFuncionario(CreateFuncionarioDto createCadastroFuncionarioDto)
        {
            var funcionario = _mapper.Map<Funcionario>(createCadastroFuncionarioDto);
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
        }

        public IEnumerable<ReadFuncionarioDto> GetCadastroFuncionario(PaginationParameters parameters)
        {
            var funcionarios = _context.Funcionarios
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToList(); ;
            var funcionariosDto = _mapper.Map<List<ReadFuncionarioDto>>(funcionarios);
            return funcionariosDto.ToList();
        }

        public ReadFuncionarioDto? GetCadastroFuncionarioById(int id)
        {
            var funcionarios = _context.Funcionarios.FirstOrDefault(funcionarios => funcionarios.Id == id);
            var funcionariosDto = _mapper.Map<ReadFuncionarioDto>(funcionarios);
            return funcionariosDto;
        }


        public bool DeleteCadastroFuncionario(int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.Id == id);
            if (funcionario == null)
            {
                return false;
            }
            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
            return true;
        }
    }
}
