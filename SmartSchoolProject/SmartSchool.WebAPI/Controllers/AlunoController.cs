using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>() 
        {
            new Aluno() {
                Id = 1,
                Nome = "Dimas",
                Sobrenome = "Parreiras",
                Telefone = "37999851327"
            },
            new Aluno() {
                Id = 2,
                Nome = "Filipe",
                Sobrenome = "Nascimento",
                Telefone = "37999850852"
            },
            new Aluno() {
                Id = 3,
                Nome = "Guilherme",
                Sobrenome = "Silva",
                Telefone = "37999846352"
            },
        };
        public AlunoController() { }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a =>  a.Id == id);
            if (aluno == null)
                return BadRequest("O código de aluno informado não está registrado!");
            else 
                return Ok(aluno);
        }

        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(
                a =>  a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null)
                return BadRequest("O código de aluno informado não está registrado!");
            else 
                return Ok(aluno);
        }
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("Cadastro deletado!");
        }
    } 
}