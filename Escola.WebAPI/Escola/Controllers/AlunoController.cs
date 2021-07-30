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

        private readonly IRepository _repo;
        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Método responsável por retornar todos os alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        /// <summary>
        /// Método responsável por retornar um aluno conforme ID informada
        /// </summary>
        /// <returns></returns>
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, true);
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
            _repo.Add(aluno);
            if (_repo.SaveChanges())
                return Ok(aluno);
            else
                return BadRequest("Erro ao cadastrar aluno!");
        }

        /// <summary>
        /// Método responsável por atualizar o cadastro dos alunos
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null)
                return BadRequest("O código de aluno informado não está registrado!");
            _repo.Update(aluno);
            if (_repo.SaveChanges())
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
            var alu = _repo.GetAlunoById(id);
            if (alu == null)
                return BadRequest("O código de aluno informado não está registrado!");
            _repo.Update(aluno);
            if (_repo.SaveChanges())
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
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null)
                return BadRequest("O código de aluno informado não está registrado!");
            _repo.Delete(aluno);
            if (_repo.SaveChanges())
                return Ok("Cadastro deletado com sucesso");
            else
                return BadRequest("Erro ao excluir o cadastro do aluno!");
        }
    }
}
