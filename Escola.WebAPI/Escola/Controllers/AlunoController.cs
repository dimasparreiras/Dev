using Escola.Application;
using Escola.Data;
using Escola.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Controllers
{
    /// <summary>
    /// Controle de Alunos
    /// </summary>

    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoAplicacao _alunoAplicacao;

        public AlunoController(IAlunoAplicacao alunoAplicacao)
        {
            _alunoAplicacao = alunoAplicacao;
        }

        /// <summary>
        /// Método responsável por retornar todos os alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_alunoAplicacao.Get());
        }

        /// <summary>
        /// Método responsável por retornar um aluno conforme ID informada
        /// </summary>
        /// <returns></returns>
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _alunoAplicacao.GetById(id);
            if (aluno == null)
                return BadRequest("O código de aluno informado não está registrado!");
            else
                return Ok(aluno);
        }

        /// <summary>
        /// Método responsável por adicionar novos alunos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            bool result = _alunoAplicacao.Post(aluno);
            if (result)
                return Ok(aluno);
            else
                return BadRequest("Erro ao cadastrar aluno!");
        }

        /// <summary>
        /// Método responsável por atualizar o cadastro dos alunos
        /// </summary>
        /// <returns>
        /// 1 - Aluno cadastrado
        /// 2 - O código de aluno informado não está registrado
        /// 3 - Erro ao atualizar o cadastro do aluno
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            int result = _alunoAplicacao.Put(id, aluno);
            if (result == 2)
                return BadRequest("O código de aluno informado não está registrado!");
            else if (result == 1)
                return Ok(aluno);
            else
                return BadRequest("Erro ao atualizar o cadastro do aluno!");
        }

        /// <summary>
        /// Método responsável por atualizar o cadastro dos alunos
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            int result = _alunoAplicacao.Patch(id, aluno);
            if (result == 2)
                return BadRequest("O código de aluno informado não está registrado!");
            else if (result == 1)
                return Ok(aluno);
            else
                return BadRequest("Erro ao atualizar o cadastro do aluno!");
        }

        /// <summary>
        /// Método responsável por deletar o cadastro de um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int result = _alunoAplicacao.Delete(id);
            if (result == 2)
                return BadRequest("O código de aluno informado não está registrado!");
            else if (result == 1)
                return Ok("Aluno excluído com sucesso");
            else
                return BadRequest("Erro ao atualizar o cadastro do aluno!");
        }
    }
}
