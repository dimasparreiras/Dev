using Escola.Data;
using Escola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Application
{
    public interface IAlunoAplicacao
    {
        /// <summary>
        /// Método responsável por retornar todos os alunos
        /// </summary>
        /// <returns></returns>
        Aluno[] Get();


        /// <summary>
        /// Método responsável por retornar um aluno conforme ID informada
        /// </summary>
        /// <returns></returns>
        Aluno GetById(int id);

        /// <summary>
        /// Método responsável por adicionar novos alunos
        /// </summary>
        /// <returns></returns>

        bool Post(Aluno aluno);

        /// <summary>
        /// Método responsável por atualizar o cadastro dos alunos
        /// </summary>
        /// <returns></returns>
        int Put(int id, Aluno aluno);

        /// <summary>
        /// Método responsável por atualizar o cadastro dos alunos
        /// </summary>
        /// <returns></returns>
        int Patch(int id, Aluno aluno);

        /// <summary>
        /// Método responsável por deletar o cadastro de um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);
    }
}
