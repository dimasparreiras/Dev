using Escola.Data;
using Escola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Application
{
    public class AlunoAplicacao : IAlunoAplicacao
    {

        private readonly IRepository _repo;
        public AlunoAplicacao(IRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Método responsável por retornar todos os alunos
        /// </summary>
        /// <returns></returns>
        public Aluno[] Get()
        {
           var result = _repo.GetAllAlunos(true);
            return result.ToArray();
        }

        /// <summary>
        /// Método responsável por retornar um aluno conforme ID informada
        /// </summary>
        /// <returns></returns>
        public Aluno GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, true);
            return aluno;
        }

        /// <summary>
        /// Método responsável por adicionar novos alunos
        /// </summary>
        /// <returns></returns>
        public bool Post(Aluno aluno)
        {
            _repo.Add(aluno);
            return _repo.SaveChanges();
        }

        /// <summary>
        /// Método responsável por atualizar o cadastro dos alunos
        /// </summary>
        /// <returns>
        /// 1 - Aluno cadastrado
        /// 2 - O código de aluno informado não está registrado
        /// 3 - Erro ao atualizar o cadastro do aluno
        /// </returns>
        public int Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null)
                return 2;
            _repo.Update(aluno);
            if (_repo.SaveChanges())
               return 1;
            else
                return 3;
        }

        /// <summary>
        /// Método responsável por atualizar o cadastro dos alunos
        /// </summary>
        /// <returns>
        /// 1 - Aluno cadastrado
        /// 2 - O código de aluno informado não está registrado
        /// 3 - Erro ao atualizar o cadastro do aluno
        /// </returns>
        public int Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null)
                return 2;
            _repo.Update(aluno);
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
        /// 1 - Aluno excluído
        /// 2 - O código de aluno informado não está registrado
        /// 3 - Erro ao excluir o cadastro do aluno
        /// </returns>
        public int Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null)
                return 2;
            _repo.Delete(aluno);
            if (_repo.SaveChanges())
                return 1;
            else
                return 3;
        }
    }
}
