using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Domains
{
    public class Categoria
    {
        public Categoria()
        {
            IdCategoria = Guid.NewGuid();
            Objetivos = new HashSet<Objetivo>();
        }
        [Key]
        public Guid IdCategoria { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Objetivo>Objetivos { get; set; }
        
    }
}
