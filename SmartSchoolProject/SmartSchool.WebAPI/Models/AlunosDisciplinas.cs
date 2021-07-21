namespace SmartSchool.WebAPI.Models
{
    public class AlunosDisciplinas
    {
        public AlunosDisciplinas() { }
        public AlunosDisciplinas(int alunoId, Aluno aluno, int disciplinaId, Disciplina disciplina)
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