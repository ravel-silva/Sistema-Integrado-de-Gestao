using Microsoft.EntityFrameworkCore;
using Sistema_Integrado_de_Gestao.Domain.Entities;
using Sistema_Integrado_de_Gestao.Domain.Interfaces;
using Sistema_Integrado_de_Gestao.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Infra.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _context;
        public FuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Funcionario> Incluir(Funcionario funcionario)
        {
            _context.Add(funcionario);
            await _context.SaveChangesAsync();
            return funcionario;
        }

        public async Task<Funcionario> AlterarPorId(Funcionario funcionario)
        {
            _context.Update(funcionario);
            await _context.SaveChangesAsync();
            return funcionario;
        }

        public async Task<Funcionario> AlterarPorNome(Funcionario funcionario)
        {
            _context.Update(funcionario);
            await _context.SaveChangesAsync();
            return funcionario;
        }

        public async Task<Funcionario> Excluir(int id)
        {
            var funcionario = _context.Funcionarios.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario.Result);
                await _context.SaveChangesAsync();
                return funcionario.Result;
            }
            return null;
        }

        public async Task<Funcionario> SelecionarPorId(int id)
        {
            return await _context.Funcionarios.Where(funcionario => funcionario.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Funcionario> SelecionarPorNome(string nome)
        {
            return await _context.Funcionarios.Where(funcionario => funcionario.Nome == nome).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Funcionario>> SelecionarTodos()
        {
            return await _context.Funcionarios.ToListAsync();
        }
    }
}
