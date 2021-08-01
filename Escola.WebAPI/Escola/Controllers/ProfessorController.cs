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
    /// Controle de Professores
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorAplicacao _professorAplicacao;

        public ProfessorController(IProfessorAplicacao professorAplicacao)
        { 
            _professorAplicacao = professorAplicacao;
        }

        /// <summary>
        /// Método responsável por retornar todos os professores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_professorAplicacao.Get());
        }

        /// <summary>
        /// Método responsável por retornar um professor conforme ID informada
        /// </summary>
        /// <returns></returns>
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var professor = _professorAplicacao.GetById(id);
            if (professor == null)
                return BadRequest("O código de professor informado não está registrado!");
            else
                return Ok(professor);
        }

        /// <summary>
        /// Método responsável por inserir o cadastro de um professor
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            bool result = _professorAplicacao.Post(professor);
            if (result)
                return Ok(professor);
            else
                return BadRequest("Erro ao cadastrar professor!");
        }

        /// <summary>
        /// Método responsável por atualizar cadastro de um professor
        /// </summary>
        /// <returns>
        /// 1 - Professor cadastrado
        /// 2 - O código de professor informado não está registrado
        /// 3 - Erro ao atualizar o cadastro do professor</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            int result = _professorAplicacao.Put(id, professor);
            if (result == 2)
                return BadRequest("O código de professor informado não está registrado!");
            else if (result == 1)
                return Ok(professor);
            else
                return BadRequest("Erro ao atualizar o cadastro do professor!");
        }
        /// <summary>
        /// Método responsável por atualizar cadastro de um professor
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            int result = _professorAplicacao.Put(id, professor);
            if (result == 2)
                return BadRequest("O código de professor informado não está registrado!");
            else if (result == 1)
                return Ok(professor);
            else
                return BadRequest("Erro ao atualizar o cadastro do professor!");
        }
        /// <summary>
        /// Método responsável por remover o cadastro de um professor
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int result = _professorAplicacao.Delete(id);
            if (result == 2)
                return BadRequest("O código de aluno informado não está registrado!");
            else if (result == 1)
                return Ok("Cadastro deletado com sucesso");
            else
                return BadRequest("Erro ao excluir o cadastro do aluno!");
        }

    }
}
