using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Domains
{
    public class Perfil
    {
        [Key]
        public Guid IdPerfil { get; set; }

        public string Permissao { get; set; }


        public virtual ICollection<Usuario> Usuario { get; set; }
        public Perfil()
        {
            IdPerfil = Guid.NewGuid();
        }
    }
}
