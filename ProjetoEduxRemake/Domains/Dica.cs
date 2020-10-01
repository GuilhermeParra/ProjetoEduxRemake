using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Domains
{
    public class Dica
    {
        [Key]
        public Guid IdDica { get; set; }
        public string Texto { get; set; }
        [NotMapped]
        public IFormFile ImagemNova {get; set;}
        public string UrlImagem { get; set; }
        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        
        public virtual ICollection<Curtida> Curtidas { get; set; }
        public Dica()
        {
            IdDica = Guid.NewGuid();
            Curtidas = new HashSet<Curtida>();
        }
    }
}
