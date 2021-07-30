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
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Método responsável por retornar todos os professores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        /// <summary>
        /// Método responsável por retornar um professor conforme ID informada
        /// </summary>
        /// <returns></returns>
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, true);
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
            _repo.Add(professor);
            if (_repo.SaveChanges())
                return Ok(professor);
            else
                return BadRequest("Erro ao cadastrar professor!");
        }

        /// <summary>
        /// Método responsável por atualizar cadastro de um professor
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null)
                return BadRequest("O código de professor informado não está registrado!");
            _repo.Update(professor);
            if (_repo.SaveChanges())
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
            var prof = _repo.GetProfessorById(id);
            if (prof == null)
                return BadRequest("O código de professor informado não está registrado!");
            _repo.Update(professor);
            if (_repo.SaveChanges())
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
            var professor = _repo.GetProfessorById(id);
            if (professor == null)
                return BadRequest("O código de aluno informado não está registrado!");
            _repo.Delete(professor);
            if (_repo.SaveChanges())
                return Ok("Cadastro deletado com sucesso");
            else
                return BadRequest("Erro ao excluir o cadastro do aluno!");
        }

    }
}
