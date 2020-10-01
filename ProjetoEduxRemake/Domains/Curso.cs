using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ProjetoEduxRemake.Domains
{
    public class Curso 
    {
        public Curso()
        {
            IdCurso = Guid.NewGuid();
            Turmas = new HashSet<Turma>();
        }
        [Key]
        public Guid IdCurso { get; set; }
        public string Titulo { get; set; }
        public Guid IdInstituicao { get; set; }
        [ForeignKey("IdInstituicao")]
        public Instituicao Instituicao { get; set; }

        
        public virtual ICollection<Turma> Turmas { get; set; }
        
    }
}
