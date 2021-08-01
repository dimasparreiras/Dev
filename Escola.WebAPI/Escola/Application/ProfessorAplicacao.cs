using Escola.Data;
using Escola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Application
{
    public class ProfessorAplicacao : IProfessorAplicacao
    {
        private readonly IRepository _repo;
        public ProfessorAplicacao(IRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Método responsável por retornar todos os alunos
        /// </summary>
        /// <returns></returns>
        public Professor[] Get()
        {
            var result = _repo.GetAllProfessores(true);
            return result.ToArray();
        }

        /// <summary>
        /// Método responsável por retornar um aluno conforme ID informada
        /// </summary>
        /// <returns></returns>
        public Professor GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, true);
            return professor;
        }

        /// <summary>
        /// Método responsável por adicionar novos alunos
        /// </summary>
        /// <returns></returns>
        public bool Post(Professor professor)
        {
            _repo.Add(professor);
            return _repo.SaveChanges();
        }

        /// <summary>
        /// Método responsável por atualizar o cadastro dos alunos
        /// </summary>
        /// <returns>
        /// 1 - Professor cadastrado
        /// 2 - O código de professor informado não está registrado
        /// 3 - Erro ao atualizar o cadastro do professor
        /// </returns>
        public int Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null)
                return 2;
            _repo.Update(professor);
            if (_repo.SaveChanges())
                return 1;
            else
                return 3;
        }

        /// <summary>
        /// Método responsável por atualizar o cadastro dos alunos
        /// </summary>
        /// <returns>
        /// 1 - Professor cadastrado
        /// 2 - O código de professor informado não está registrado
        /// 3 - Erro ao atualizar o cadastro do professor
        /// </returns>
        public int Patch(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null)
                return 2;
            _repo.Update(professor);
            if (_repo.SaveChanges())
                return 1;
            else
                return 3;
        }

        /// <summary>
        /// Método responsável por deletar o cadastro de um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 1 - Professor excluído
        /// 2 - O código de professor informado não está registrado
        /// 3 - Erro ao excluir o cadastro do professor
        /// </returns>
        public int Delete(int id)
        {
            var professor = _repo.GetAlunoById(id);
            if (professor == null)
                return 2;
            _repo.Delete(professor);
            if (_repo.SaveChanges())
                return 1;
            else
                return 3;
        }
    }
}

