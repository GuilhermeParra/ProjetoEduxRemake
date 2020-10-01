using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Domains
{
    public class Instituicao
    {
        public Instituicao()
        {
            IdInstituicao = Guid.NewGuid();
            Cursos = new HashSet<Curso>();
        }
        [Key]
        public Guid IdInstituicao { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
        
    }
}
