using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Domains
{
    public class Curtida
    {
        [Key]
        public Guid IdCurtida { get; set; }
        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public Guid IdDica { get; set; }
        [ForeignKey("IdDica")]
        public Dica Dica { get; set; }

        public Curtida()
        {
            IdCurtida = Guid.NewGuid();
                
        }
        
    }
}
