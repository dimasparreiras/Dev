using Escola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Application
{
    public interface IProfessorAplicacao 
    {
        /// <summary>
        /// Método responsável por retornar todos os alunos
        /// </summary>
        /// <returns></returns>
        Professor[] Get();


        /// <summary>
        /// Método responsável por retornar um aluno conforme ID informada
        /// </summary>
        /// <returns></returns>
        Professor GetById(int id);

        /// <summary>
        /// Método responsável por adicionar novos alunos
        /// </summary>
        /// <returns></returns>

        bool Post(Professor professor);

        /// <summary>
        /// Método responsável por atualizar o cadastro dos alunos
        /// </summary>
        /// <returns></returns>
        int Put(int id, Professor professor);

        /// <summary>
        /// Método responsável por atualizar o cadastro dos alunos
        /// </summary>
        /// <returns></returns>
        int Patch(int id, Professor professor);

        /// <summary>
        /// Método responsável por deletar o cadastro de um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);
    }
}
