using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Domains
{
    public class Usuario
    {
        public Usuario()
        {
            IdUsuario = Guid.NewGuid();
            AlunosTurmas = new HashSet<AlunoTurma>();
            Curtidas = new HashSet<Curtida>();
            Dicas = new HashSet<Dica>();
            ProfessoresTurma = new HashSet<ProfessorTurma>();
        }
        [Key]
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimoAcesso { get; set; }
        public Guid IdPerfil { get; set; }
        [ForeignKey("IdPerfil")]
        public Perfil Perfil { get; set; }


        //public virtual ICollection<Curtida> Curtidas { get; set; }
        
        public virtual ICollection<AlunoTurma> AlunosTurmas { get; set; }
        public virtual ICollection<ProfessorTurma> ProfessoresTurma { get; set; }
        public virtual ICollection<Curtida> Curtidas { get; set; }
        public virtual ICollection<Dica> Dicas { get; set; }
        
       
    }
}
