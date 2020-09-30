using ProjetoEduxRemake.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Interfaces
{
    interface IUsuario
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(Guid id);
        void Editar(Usuario usuario);
        void Adicionar(Usuario usuario);
        void Remover(Guid id);
    }
}
