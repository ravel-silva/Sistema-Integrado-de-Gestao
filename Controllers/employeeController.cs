﻿using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;
using Solicitacao_de_Material.Services;

namespace Solicitacao_de_Material.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        
        private EmployeeService _service;
        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult CreateFuncionario([FromBody] CreateFuncionarioDto CadastroFuncionarioDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.CreateCadastroFuncionario(CadastroFuncionarioDto);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetFuncionarios(PaginationParameters parameters)
        {
            if (_service.GetCadastroFuncionario(parameters) == null || !_service.GetCadastroFuncionario(parameters).Any())
            {
                return NotFound("Nenhum funcionario localizado");
            }
            return Ok(_service.GetCadastroFuncionario(parameters));

        }

        [HttpGet("{id}")]
        public IActionResult GetFuncionarioById(int id)
        {
            if (_service.GetCadastroFuncionarioById(id) == null || !_service.GetCadastroFuncionarioById(id).Any())
            {
                return NotFound("Funcionario não localizado");
            }
            return Ok(_service.GetCadastroFuncionarioById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFuncionario(int id)
        {
            if (!_service.DeleteCadastroFuncionario(id))
            {
                return NotFound("Funcionario não localizado");
            }
            return Ok("Funcionario deletado com sucesso");
        }
    }
}
