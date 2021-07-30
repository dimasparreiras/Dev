using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() { }
        public AlunoDisciplina(int alunoId, Aluno aluno, int disciplinaId, Disciplina disciplina)
        {
            this.AlunoId = alunoId;
            this.Aluno = aluno;
            this.DisciplinaId = disciplinaId;
            this.Disciplina = disciplina;

        }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
