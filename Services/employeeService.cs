﻿using Microsoft.EntityFrameworkCore;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Services
{
    public class EmployeeService
    {
        private AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCadastroFuncionario(CreateFuncionarioDto createCadastroFuncionarioDto)
        {
            var funcionario = new Funcionario
            {
                Nome = createCadastroFuncionarioDto.Nome,
                Matricula = createCadastroFuncionarioDto.Matricula.ToString(),
                DataCriacao = createCadastroFuncionarioDto.DataCriacao
            };
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
        }
        // get
        public IEnumerable<ReadFuncionarioDto> GetCadastroFuncionario(PaginationParameters parameters)
        {
            var funcionarios = _context.Funcionarios.Select(funcionario => new ReadFuncionarioDto
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Matricula = funcionario.Matricula.ToString(),
                DataCriacao = funcionario.DataCriacao
            }).Skip((parameters.PageNumber - 1)
            * parameters.PageSize)
            .Take(parameters.PageSize);
            return funcionarios.ToList();
        }

        public IEnumerable<ReadFuncionarioDto> GetCadastroFuncionarioById(int id)
        {
            var funcionarios = _context.Funcionarios.Where(funcionarios => funcionarios.Id == id).Select(funcionarios => new ReadFuncionarioDto
            {
                Id = funcionarios.Id,
                Nome = funcionarios.Nome,
                Matricula = funcionarios.Matricula.ToString(),
                DataCriacao = funcionarios.DataCriacao
            });
            return funcionarios.ToList();
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
