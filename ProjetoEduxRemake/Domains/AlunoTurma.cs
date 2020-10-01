using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Domains
{
    public class AlunoTurma 
    {
        public AlunoTurma()
        {
            IdAlunoTurma = Guid.NewGuid();
            ObjetivoAlunos = new HashSet<ObjetivoAluno>();
        }
        [Key]
        public Guid IdAlunoTurma { get; set; }
        public string Matricula { get; set; }
        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public Guid IdTurma { get; set; }
        [ForeignKey("IdTurma")]
        public Turma Turma { get; set; }

        
        public virtual ICollection<ObjetivoAluno>ObjetivoAlunos { get; set; }
    }
}
