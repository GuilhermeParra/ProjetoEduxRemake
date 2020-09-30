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

        public Usuario()
        {
            IdUsuario = Guid.NewGuid();
        }
    }
}
