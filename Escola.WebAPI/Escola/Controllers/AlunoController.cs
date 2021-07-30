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
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {

        private readonly IRepository _repo;
        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, true);
            if (aluno == null)
                return BadRequest("O código de aluno informado não está registrado!");
            else
                return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
                return Ok(aluno);
            else
                return BadRequest("Erro ao cadastrar aluno!");
        }

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
