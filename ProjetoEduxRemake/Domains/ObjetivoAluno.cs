using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Domains
{
    public class ObjetivoAluno
    {
        [Key]
        public Guid IdObjetivoAluno { get; set; }
        public decimal Nota { get; set; }
        public DateTime DataAlcancado { get; set; }
        public Guid IdAlunoTurma { get; set; }
        [ForeignKey("IdAlunoTurma")]
        public AlunoTurma AlunoTurma { get; set; }
        public Guid IdObjetivo { get; set; }
        [ForeignKey("IdObjetivo")]
        public Objetivo Objetivo { get; set; }

        [JsonIgnore]
        public virtual AlunoTurma IdAlunoTurmaNavigation { get; set; }
        public virtual Objetivo IdObjetivoNavigation { get; set; }
        public ObjetivoAluno()
        {
            IdObjetivoAluno = Guid.NewGuid();
        }
    }
}
