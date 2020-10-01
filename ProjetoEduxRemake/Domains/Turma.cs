using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Domains
{
    public class Turma
    {
        [Key]
        public Guid IdTurma { get; set; }
        public string Descricao { get; set; }
        public Guid IdCurso { get; set; }
        [ForeignKey("IdCurso")]
        public Curso Curso { get; set; }

        [JsonIgnore]
        public virtual Curso IdCursoNavigation { get; set; }
        public virtual ICollection<AlunoTurma> AlunoTurma { get; set; }
        public virtual ICollection<ProfessorTurma> ProfessorTurma { get; set; }
        public Turma()
        {
            IdTurma = Guid.NewGuid();
        }
    }
}
