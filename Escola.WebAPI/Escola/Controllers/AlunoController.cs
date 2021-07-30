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
        private readonly EscolaContext _context;

        public AlunoController(EscolaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
                return BadRequest("O código de aluno informado não está registrado!");
            else
                return Ok(aluno);
        }

        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(
                a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null)
                return BadRequest("O código de aluno informado não está registrado!");
            else
                return Ok(aluno);
        }
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            if (_context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id) == null)
                return BadRequest("O aluno informado não está registrado!");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            if (_context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id) == null)
                return BadRequest("O aluno informado não está registrado!");
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (aluno == null)
                return BadRequest("O aluno informado não está registrado!");
            else
            {
                _context.Remove(aluno);
                _context.SaveChanges();
                return Ok(aluno);
            }
        }
    }
}
