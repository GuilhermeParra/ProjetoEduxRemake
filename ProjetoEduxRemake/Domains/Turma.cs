using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

        public Turma()
        {
            IdTurma = Guid.NewGuid();
        }
    }
}
