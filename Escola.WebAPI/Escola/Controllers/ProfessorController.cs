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
    public class ProfessorController : ControllerBase
    {
        private readonly EscolaContext _context;

        public ProfessorController(EscolaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var prof = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (prof == null)
                return BadRequest("O código informado não pertence a nenhum Professor!");
            else
                return Ok(prof);
        }

        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {
            var prof = _context.Professores.FirstOrDefault(
                a => a.Nome.Contains(nome));
            if (prof == null)
                return BadRequest("O código de aluno informado não está registrado!");
            else
                return Ok(prof);
        }
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            if (_context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id) == null)
                return BadRequest("O aluno informado não está registrado!");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            if (_context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id) == null)
                return BadRequest("O aluno informado não está registrado!");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null)
                return BadRequest("O aluno informado não está registrado!");
            else
            {
                _context.Remove(prof);
                _context.SaveChanges();
                return Ok(prof);
            }
        }

    }
}
